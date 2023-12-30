using Academia.GestionInventario.WebApi._Infrastructure.Entities.Productos;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.ProductosLotes;
using Academia.GestionInventario.WebApi.DomainServices.ProductosLotes;
using Academia.GestionInventario.WebApi.Models.ProductosLotes;
using Academia.Transporte.WebApi._Commons.Codigos;
using Academia.Transporte.WebApi._Infrastructure;
using ContabilidadValesCajaChicaApi._Commons.MensajesGlobales;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using Mapster;

namespace Academia.GestionInventario.WebApi.AppServices.ProductosLotes
{
    public class ProductoLoteAppService : IProductoLoteAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductoLoteDomainService _loteDomainService;
        public ProductoLoteAppService(UnitOfWorkBuilder unitOfWorkBuilder, ProductoLoteDomainService loteDomainService)
        {
            _unitOfWork = unitOfWorkBuilder.BuilderGestionInventarioDbContext();
            _loteDomainService = loteDomainService;
        }

        public Respuesta<ActualizarProductosLotesDto> ActualizarProductoLote(ActualizarProductosLotesDto productoDto)
        {
            string mensaje = string.Empty;
            bool sePuedeActualizar = _loteDomainService.SePuedeActualizarLote(productoDto, out mensaje);

            if (!sePuedeActualizar)
            {
                return Respuesta.Fault<ActualizarProductosLotesDto>(mensaje, Codigo.ADVERTENCIA);
            }

            ProductosLote? productoLote = _unitOfWork.Repository<ProductosLote>().AsQueryable()
                .FirstOrDefault(x => x.LoteId == productoDto.LoteId);

            if (productoLote == null)
            {
                return Respuesta.Fault<ActualizarProductosLotesDto>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            productoLote.CantidadInicial = productoDto.CantidadInicial;
            productoLote.Costo = productoDto.Costo;
            productoLote.Inventario = productoDto.Inventario;
            productoLote.FechaVencimiento = productoDto.FechaVencimiento;
            productoLote.FechaModificacion = productoDto.FechaModificacion;
            productoLote.UsuarioModificacionId = productoDto.UsuarioModificacionId;

            _unitOfWork.Repository<ProductosLote>().Update(productoLote);
            _unitOfWork.SaveChanges();

            return Respuesta.Success<ActualizarProductosLotesDto>(null!, mensaje, Codigo.EXITO);
        }

        public Respuesta<AgregarProductosLoteDto> AgregarProductoLote(AgregarProductosLoteDto productoDto)
        {
            string mensaje = string.Empty;
            bool sePuedeAgregar = _loteDomainService.SePuedeAgregarLote(productoDto, out mensaje);

            if (!sePuedeAgregar)
            {
                return Respuesta.Fault<AgregarProductosLoteDto>(mensaje, Codigo.ADVERTENCIA);
            }

            ProductosLote productoLote = productoDto.Adapt<ProductosLote>();

            _unitOfWork.Repository<ProductosLote>().Add(productoLote);
            _unitOfWork.SaveChanges();

            return Respuesta.Success<AgregarProductosLoteDto>(null!, mensaje, Codigo.EXITO);
        }

        public Respuesta<ProductosLote> CambiarEstadoProductoLote(int? productoLoteId, int? usuarioId, bool estado)
        {
            string mensaje = string.Empty;
            bool sePuedeCambiarEstadoSucursal = _loteDomainService.SePuedeCambiarEstadoLote(productoLoteId, usuarioId, out mensaje);

            if (!sePuedeCambiarEstadoSucursal)
            {
                return Respuesta.Fault<ProductosLote>(mensaje, Codigo.ADVERTENCIA);
            }

            ProductosLote? productoLote = _unitOfWork.Repository<ProductosLote>().AsQueryable()
                .FirstOrDefault(x => x.LoteId == productoLoteId);

            if (productoLote == null)
            {
                return Respuesta.Fault<ProductosLote>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            bool validarEstadoSucursal = _loteDomainService.ValidarEstadoLote(estado, productoLote.Activo, out mensaje);

            if (!validarEstadoSucursal)
            {
                return Respuesta.Fault<ProductosLote>(mensaje, Codigo.ADVERTENCIA);
            }

            productoLote.Activo = estado;
            productoLote.UsuarioModificacionId = usuarioId;
            productoLote.FechaModificacion = DateTime.Now;

            _unitOfWork.Repository<ProductosLote>().Update(productoLote);
            _unitOfWork.SaveChanges();

            return Respuesta.Success<ProductosLote>(null!, MensajesGlobales.Exito, Codigo.EXITO);
        }

        public Respuesta<ObtenerProductoLoteDto> ObtenerLotePorFechaVecimiento(int productoId)
        {
            if (productoId <= 0)
            {
                return Respuesta.Fault<ObtenerProductoLoteDto>(MensajesGlobales.Data_Null, Codigo.ADVERTENCIA);
            }

            ObtenerProductoLoteDto? loteDto = (from lotes in _unitOfWork.Repository<ProductosLote>().AsQueryable()
                                               join producto in _unitOfWork.Repository<Producto>().AsQueryable()
                                               on lotes.ProductoId equals producto.ProductoId
                                               where (lotes.ProductoId == productoId && lotes.Activo)
                                               select new ObtenerProductoLoteDto
                                               {
                                                   LoteId = lotes.LoteId,
                                                   ProductoId = producto.ProductoId,
                                                   NombreProducto = producto.Nombre,
                                                   Costo = lotes.Costo,
                                                   Inventario = lotes.Inventario,
                                                   FechaVencimiento = lotes.FechaVencimiento
                                               }).OrderBy(lote => lote.FechaVencimiento).FirstOrDefault();
            if (loteDto == null)
            {
                return Respuesta.Fault<ObtenerProductoLoteDto>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            return Respuesta.Success(loteDto, MensajesGlobales.Exito, Codigo.EXITO);
        }

        public Respuesta<List<ObtenerProductoLoteDto>> ObtenerProductosLotes()
        {
            List<ObtenerProductoLoteDto> productos = (from lotes in _unitOfWork.Repository<ProductosLote>().AsQueryable()
                                                      join producto in _unitOfWork.Repository<Producto>().AsQueryable()
                                                      on lotes.ProductoId equals producto.ProductoId
                                                      where lotes.Activo
                                                      select new ObtenerProductoLoteDto
                                                      {
                                                          LoteId = lotes.LoteId,
                                                          ProductoId = producto.ProductoId,
                                                          NombreProducto = producto.Nombre,
                                                          Costo = lotes.Costo,
                                                          Inventario = lotes.Inventario,
                                                          FechaVencimiento = lotes.FechaVencimiento
                                                      }).ToList();
            if (!productos.Any())
            {
                return Respuesta.Fault<List<ObtenerProductoLoteDto>>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            return Respuesta.Success(productos, MensajesGlobales.Exito, Codigo.EXITO);
        }
    }
}
