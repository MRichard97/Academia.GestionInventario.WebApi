using Academia.GestionInventario.WebApi._Infrastructure.Entities.Productos;
using Academia.GestionInventario.WebApi.DomainServices.Productos;
using Academia.GestionInventario.WebApi.Models.Productos;
using Academia.Transporte.WebApi._Commons.Codigos;
using Academia.Transporte.WebApi._Infrastructure;
using ContabilidadValesCajaChicaApi._Commons.MensajesGlobales;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using Mapster;

namespace Academia.GestionInventario.WebApi.AppServices.Productos
{
    public class ProductoAppService : IProductoAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductoDomainService _productoDomainService;

        public ProductoAppService(UnitOfWorkBuilder unitOfWorkBuilder, ProductoDomainService productoDomainService)
        {
            _unitOfWork = unitOfWorkBuilder.BuilderGestionInventarioDbContext();
            _productoDomainService = productoDomainService;
        }

        public Respuesta<ActualizarProductoDto> ActualizarProducto(ActualizarProductoDto productoDto)
        {
            string mensaje = string.Empty;
            bool sePuedeActualizar = _productoDomainService.SePuedeActualizarProducto(productoDto, out mensaje);

            if (!sePuedeActualizar)
            {
                return Respuesta.Fault<ActualizarProductoDto>(mensaje, Codigo.ADVERTENCIA);
            }

            Producto? producto = _unitOfWork.Repository<Producto>().AsQueryable()
                .FirstOrDefault(x => x.ProductoId == productoDto.ProductoId && x.Activo);

            if (producto == null)
            {
                return Respuesta.Fault<ActualizarProductoDto>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }


            bool validarNombreUnico = _productoDomainService.ValidarNombreUnico(producto.Nombre!, productoDto.Nombre!, out mensaje);
            if (!validarNombreUnico)
            {
                return Respuesta.Fault<ActualizarProductoDto>(mensaje, Codigo.ADVERTENCIA);
            }

            producto.Nombre = productoDto.Nombre!;
            producto.FechaModificacion = productoDto.FechaModificacion;
            producto.UsuarioModificacionId = productoDto.UsuarioModificacionId;

            _unitOfWork.Repository<Producto>().Update(producto);
            _unitOfWork.SaveChanges();

            return Respuesta.Success<ActualizarProductoDto>(null!, mensaje, Codigo.EXITO);
        }

        public Respuesta<AgregarProductoDto> AgregarProducto(AgregarProductoDto productoDto)
        {
            string mensaje = string.Empty;
            bool sePuedeAgregar = _productoDomainService.SePuedeAgregarProducto(productoDto, out mensaje);

            if (!sePuedeAgregar)
            {
                return Respuesta.Fault<AgregarProductoDto>(mensaje, Codigo.ADVERTENCIA);
            }

            string? nombreProducto = (from productos in _unitOfWork.Repository<Producto>().AsQueryable()
                                      where productos.Nombre == productoDto.Nombre
                                      select productos.Nombre).FirstOrDefault();

            if (string.IsNullOrEmpty(nombreProducto))
            {
                return Respuesta.Fault<AgregarProductoDto>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }


            bool validarNombreUnico = _productoDomainService.ValidarNombreUnico(nombreProducto, productoDto.Nombre, out mensaje);

            if (!validarNombreUnico)
            {
                return Respuesta.Fault<AgregarProductoDto>(mensaje, Codigo.ADVERTENCIA);
            }

            Producto producto = productoDto.Adapt<Producto>();

            _unitOfWork.Repository<Producto>().Add(producto);
            _unitOfWork.SaveChanges();

            return Respuesta.Success<AgregarProductoDto>(null!, mensaje, Codigo.EXITO);
        }

        public Respuesta<Producto> CambiarEstadoProducto(int productoId, int usuarioId, bool estado)
        {
            string mensaje = string.Empty;
            bool sePuedeCambiarEstado = _productoDomainService.SePuedeCambiarEstadoProducto(productoId, usuarioId, out mensaje);

            if (!sePuedeCambiarEstado)
            {
                return Respuesta.Fault<Producto>(mensaje, Codigo.ADVERTENCIA);
            }

            Producto? producto = _unitOfWork.Repository<Producto>().AsQueryable()
                .FirstOrDefault(x => x.ProductoId == productoId);

            if (producto == null)
            {
                return Respuesta.Fault<Producto>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            bool validarEstadoSucursal = _productoDomainService.ValidarEstadoProducto(estado, producto.Activo, out mensaje);

            if (!validarEstadoSucursal)
            {
                return Respuesta.Fault<Producto>(mensaje, Codigo.ADVERTENCIA);
            }

            producto.Activo = estado;
            producto.UsuarioModificacionId = usuarioId;
            producto.FechaModificacion = DateTime.Now;

            _unitOfWork.Repository<Producto>().Update(producto);
            _unitOfWork.SaveChanges();

            return Respuesta.Success<Producto>(null!, MensajesGlobales.Exito, Codigo.EXITO);
        }

        public Respuesta<List<ObtenerProductoDto>> ObtenerProductos()
        {
            List<ObtenerProductoDto> productos = (from producto in _unitOfWork.Repository<Producto>().AsQueryable()
                                                  where producto.Activo
                                                  select new ObtenerProductoDto
                                                  {
                                                      ProductoId = producto.ProductoId,
                                                      Nombre = producto.Nombre,
                                                      Activo = producto.Activo,
                                                  }).ToList();
            if (!productos.Any())
            {
                return Respuesta.Fault<List<ObtenerProductoDto>>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            return Respuesta.Success(productos, MensajesGlobales.Exito, Codigo.EXITO);
        }
    }
}
