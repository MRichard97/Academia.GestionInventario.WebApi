using Academia.GestionInventario.WebApi._Common.Enums;
using Academia.GestionInventario.WebApi._Common.Extensions;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Empleados;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Estados;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Productos;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.ProductosLotes;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventarios;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventariosDetalles;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Sucursales;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Usuarios;
using Academia.GestionInventario.WebApi.DomainServices.SalidasInventarios;
using Academia.GestionInventario.WebApi.Models.SalidasInventarios;
using Academia.GestionInventario.WebApi.Models.SalidasInventariosDetalles;
using Academia.Transporte.WebApi._Commons.Codigos;
using Academia.Transporte.WebApi._Infrastructure;
using ContabilidadValesCajaChicaApi._Commons.MensajesGlobales;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using Mapster;

namespace Academia.GestionInventario.WebApi.AppServices.SalidasInventarios
{
    public class SalidaInventrioAppService : ISalidaInventarioAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SalidaInventarioDomainService _salidaInventarioDomain;

        public SalidaInventrioAppService(UnitOfWorkBuilder unitOfWorkBuilder, SalidaInventarioDomainService salidaInventarioDomain)
        {
            _unitOfWork = unitOfWorkBuilder.BuilderGestionInventarioDbContext();
            _salidaInventarioDomain = salidaInventarioDomain;
        }

        public Respuesta<SalidaInventarioDto> AgregarSalidaInventario(AgregarSalidaInventarioDto inventarioDto)
        {
            if (inventarioDto == null)
            {
                return Respuesta.Fault<SalidaInventarioDto>(MensajesGlobales.Data_Null, Codigo.ADVERTENCIA);
            }

            string mensaje = string.Empty;

            List<ProductosLote> lotesOrdenados = (from lotes in _unitOfWork.Repository<ProductosLote>().AsQueryable()
                                                  where (lotes.ProductoId == inventarioDto.ProductoId && lotes.Activo && lotes.Inventario > 0)
                                                  select lotes
                                                  ).OrderBy(lote => lote.FechaVencimiento).ToList();

            if (!lotesOrdenados.Any())
            {
                return Respuesta.Fault<SalidaInventarioDto>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA); ;
            }

            List<SalidasInventariosDetalle> salidasDetalles = ObtenerSalidasInventariosDetalle(inventarioDto, lotesOrdenados);

            if (!salidasDetalles.Any())
            {
                return Respuesta.Fault<SalidaInventarioDto>(MensajesGlobales.No_Hay_Inventario, Codigo.ADVERTENCIA);
            }

            decimal? costoTotal = CalcularCostoTotal(salidasDetalles, lotesOrdenados);

            decimal? costoTotalSucursal = CalcularCostoTotalSucursal(inventarioDto.SucursalId, costoTotal);
            bool validarCostoTotalSucursal = _salidaInventarioDomain.ValidarCostoTotalSucursal(costoTotalSucursal, out mensaje);

            if (!validarCostoTotalSucursal)
            {
                return Respuesta.Fault<SalidaInventarioDto>(mensaje, Codigo.ADVERTENCIA);
            }

            GuardarSalidaInventario(salidasDetalles, inventarioDto, costoTotal);

            return Respuesta<SalidaInventarioDto>.Success(null!, mensaje, Codigo.EXITO);
        }
        public Respuesta<List<ObtenerSalidaInventarioDto>> ReporteSalidas(DateTime fechaInicio, DateTime fechaFinal, int sucursalId)
        {
            List<ObtenerSalidaInventarioDto> inventarioDto = ObtenerSalidasQuery()
                .Where(salida => salida.FechaSalida >= fechaInicio && salida.FechaSalida <= fechaFinal && salida.SucursalId == sucursalId)
                .ToList();

            if (!inventarioDto.Any())
            {
                return Respuesta.Fault<List<ObtenerSalidaInventarioDto>>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA); ;
            }

            return Respuesta<List<ObtenerSalidaInventarioDto>>.Success(inventarioDto, MensajesGlobales.Exito, Codigo.EXITO);
        }

        public Respuesta<ObtenerSalidaInventarioDto> ObtenerSalida(int salididaId)
        {
            ObtenerSalidaInventarioDto? inventarioDto = ObtenerSalidasQuery().Where(salida => salida.SalidaId == salididaId).FirstOrDefault();

            if (inventarioDto == null)
            {
                return Respuesta.Fault<ObtenerSalidaInventarioDto>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA); ;
            }

            return Respuesta<ObtenerSalidaInventarioDto>.Success(inventarioDto, MensajesGlobales.Exito, Codigo.EXITO);
        }

        public Respuesta<SalidasInventario> RecepcionSalida(int salididaId, int usuarioRecepcionId)
        {
            if (salididaId <= 0 || usuarioRecepcionId <= 0)
            {
                return Respuesta.Fault<SalidasInventario>(MensajesGlobales.Data_Null, Codigo.ADVERTENCIA); ;
            }

            SalidasInventario? salidasInventario = _unitOfWork.Repository<SalidasInventario>().AsQueryable()
                .FirstOrDefault(x => x.SalidaInventarioId == salididaId);

            if (salidasInventario == null)
            {
                return Respuesta.Fault<SalidasInventario>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA); ;
            }

            string mensaje = string.Empty;
            bool validarRecepcion = _salidaInventarioDomain.ValidarRecepcion(salidasInventario, out mensaje);

            if (!validarRecepcion)
            {
                return Respuesta.Fault<SalidasInventario>(mensaje, Codigo.ADVERTENCIA); ;
            }

            salidasInventario.UsuarioRecibeId = usuarioRecepcionId;
            salidasInventario.FechaRecibe = DateTime.Now;
            salidasInventario.EstadoId = (int)TypeEstadoSalidaInventario.Recibido;
            salidasInventario.FechaModificacion = DateTime.Now;
            salidasInventario.UsuarioModificacionId = usuarioRecepcionId;

            _unitOfWork.Repository<SalidasInventario>().Update(salidasInventario);
            _unitOfWork.SaveChanges();

            return Respuesta<SalidasInventario>.Success(null!, mensaje, Codigo.EXITO);

        }

        private IQueryable<ObtenerSalidaInventarioDto> ObtenerSalidasQuery()
        {
            return (
                from salida in _unitOfWork.Repository<SalidasInventario>().AsQueryable()
                join salidaDetalle in _unitOfWork.Repository<SalidasInventariosDetalle>().AsQueryable()
                    on salida.SalidaInventarioId equals salidaDetalle.SalidaInventarioId into detallesGroup
                from detalle in detallesGroup.DefaultIfEmpty()
                join sucursal in _unitOfWork.Repository<Sucursal>().AsQueryable()
                    on salida.SucursalId equals sucursal.SucursalId into sucursalGroup
                from sucursalItem in sucursalGroup.DefaultIfEmpty()
                join estado in _unitOfWork.Repository<Estado>().AsQueryable()
                    on salida.EstadoId equals estado.EstadoId into estadoGroup
                from estadoItem in estadoGroup.DefaultIfEmpty()
                join usuario in _unitOfWork.Repository<Usuario>().AsQueryable()
                    on salida.UsuarioId equals usuario.UsuarioId into usuarioGroup
                from usuarioItem in usuarioGroup.DefaultIfEmpty()
                join usuarioRecibe in _unitOfWork.Repository<Usuario>().AsQueryable()
                    on salida.UsuarioRecibeId equals usuarioRecibe.UsuarioId into usuarioRecibeGroup
                from usuarioRecibeItem in usuarioRecibeGroup.DefaultIfEmpty()
                join empleado in _unitOfWork.Repository<Empleado>().AsQueryable()
                    on usuarioRecibeItem.EmpleadoId equals empleado.EmpleadoId into empleadoGroup
                from empleadoItem in empleadoGroup.DefaultIfEmpty()
                join lote in _unitOfWork.Repository<ProductosLote>().AsQueryable()
                    on detalle.LoteId equals lote.LoteId into loteGroup
                from loteItem in loteGroup.DefaultIfEmpty()
                join productoLote in _unitOfWork.Repository<ProductosLote>().AsQueryable()
                    on loteItem.LoteId equals productoLote.LoteId into productoLoteGroup
                from productoLoteItem in productoLoteGroup.DefaultIfEmpty()
                join producto in _unitOfWork.Repository<Producto>().AsQueryable()
                    on productoLoteItem.ProductoId equals producto.ProductoId into productoGroup
                from productoItem in productoGroup.DefaultIfEmpty()
                select new ObtenerSalidaInventarioDto
                {
                    SalidaId = salida.SalidaInventarioId,
                    SucursalId = salida.SucursalId,
                    NombreProducto = productoItem.Nombre,
                    TotalUnidades = salida.ObtenerTotalUnidades(detalle),
                    TotalCosto = salida.ObtenerTotalCosto(detalle),
                    Estado = estadoItem.ObtenerEstado(),
                    UsuarioRecibe = usuarioRecibeItem.ObtenerUsuarioRecibeNombre(empleadoItem),
                    FechaSalida = salida.FechaSalida,
                    FechaRecibe = salida.ObtenerFechaRecibe()
                }
            );
        }

        private decimal? CalcularCostoTotal(List<SalidasInventariosDetalle> salidasDetalles, List<ProductosLote> lotes)
        {
            decimal? costoTotal = 0;

            foreach (var detalle in salidasDetalles)
            {
                ProductosLote? loteCorrespondiente = lotes.FirstOrDefault(lote => lote.LoteId == detalle.LoteId);

                if (loteCorrespondiente != null)
                {
                    costoTotal += detalle.CantidadProducto * loteCorrespondiente.Costo;
                }
            }

            return costoTotal;
        }

        private decimal? CalcularCostoTotalSucursal(int sucursalId, decimal? costoTotal)
        {
            decimal? costoTotalSucursal = (from salida in _unitOfWork.Repository<SalidasInventario>().AsQueryable()
                                           where salida.EstadoId == (int)TypeEstadoSalidaInventario.Enviado
                                           && salida.SucursalId == sucursalId
                                           select salida.Total).Sum() + costoTotal;
            return costoTotalSucursal;
        }

        private List<SalidasInventariosDetalle> ObtenerSalidasInventariosDetalle(AgregarSalidaInventarioDto inventarioDto, List<ProductosLote> lotesOrdenados)
        {
            int cantidadRequerida = inventarioDto.CantidadProducto;

            List<SalidasInventariosDetalle> salidasDetalles = new List<SalidasInventariosDetalle>();


            foreach (var lote in lotesOrdenados)
            {
                int cantidadDisponible = Math.Min(cantidadRequerida, (byte)lote.Inventario!);
                if (cantidadDisponible > 0)
                {
                    AgregarSalidaInventarioDetalleDto salidaDetalleDto = new AgregarSalidaInventarioDetalleDto
                    {
                        CantidadProducto = cantidadDisponible,
                        LoteId = lote.LoteId,
                        Activo = true,
                        FechaCreacion = DateTime.Now,
                        UsuarioCreacionId = inventarioDto.UsuarioId
                    };
                    SalidasInventariosDetalle salidaDetalle = salidaDetalleDto.Adapt<SalidasInventariosDetalle>();
                    salidasDetalles.Add(salidaDetalle);

                    lote.Inventario -= cantidadDisponible;
                    cantidadRequerida -= cantidadDisponible;

                    if (lote.Inventario == 0)
                    {
                        lote.Activo = false;
                    }

                    if (cantidadRequerida == 0)
                    {
                        break;
                    }
                }
            }

            return salidasDetalles;
        }

        private Respuesta<SalidaInventarioDto> GuardarSalidaInventario(
            List<SalidasInventariosDetalle> salidasDetalles,
            AgregarSalidaInventarioDto inventarioDto,
            decimal? costoTotal)
        {
            string mensaje = string.Empty;
            bool validarSalidaInventario = _salidaInventarioDomain.ValidarSalidaInventario(costoTotal, inventarioDto.SucursalId, inventarioDto.UsuarioId, out mensaje);
            if (!validarSalidaInventario)
            {
                return Respuesta.Fault<SalidaInventarioDto>(mensaje, Codigo.ADVERTENCIA);
            }

            SalidaInventarioDto salidaInventarioDto = new SalidaInventarioDto
            {
                FechaSalida = DateTime.Now,
                Total = costoTotal,
                SucursalId = inventarioDto.SucursalId,
                UsuarioId = inventarioDto.UsuarioId,
                EstadoId = (int)TypeEstadoSalidaInventario.Enviado,
                Activo = true,
                FechaCreacion = DateTime.Now,
                UsuarioCreacionId = inventarioDto.UsuarioId
            };

            SalidasInventario salidasInventario = salidaInventarioDto.Adapt<SalidasInventario>();
            try
            {
                _unitOfWork.Repository<SalidasInventario>().Add(salidasInventario);
                _unitOfWork.SaveChanges();

                foreach (var detalle in salidasDetalles)
                {
                    bool validarSalidaInventarioDetalle = _salidaInventarioDomain.ValidarSalidaInventarioDetalle(detalle.CantidadProducto, detalle.LoteId, out mensaje);
                    if (!validarSalidaInventarioDetalle)
                    {
                        return Respuesta.Fault<SalidaInventarioDto>(mensaje, Codigo.ADVERTENCIA);
                    }
                    detalle.SalidaInventarioId = salidasInventario.SalidaInventarioId;
                    _unitOfWork.Repository<SalidasInventariosDetalle>().Add(detalle);
                }

                _unitOfWork.SaveChanges();

                return Respuesta<SalidaInventarioDto>.Success(null!, MensajesGlobales.Exito, Codigo.EXITO);
            }
            catch (Exception)
            {

                return Respuesta<SalidaInventarioDto>.Success(null!, MensajesGlobales.Salida_No_Procesada, Codigo.ERROR);
            }


        }
    }
}
