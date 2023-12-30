using Academia.GestionInventario.WebApi._Infrastructure.Entities.Sucursales;
using Academia.GestionInventario.WebApi.DomainServices.Sucursales;
using Academia.GestionInventario.WebApi.Models.Sucursales;
using Academia.Transporte.WebApi._Commons.Codigos;
using Academia.Transporte.WebApi._Infrastructure;
using ContabilidadValesCajaChicaApi._Commons.MensajesGlobales;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using Mapster;

namespace Academia.GestionInventario.WebApi.AppServices.Sucursales
{
    public class SucursalAppServices : ISucursalAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SucursalDomainService _sucursalDomainService;
        public SucursalAppServices(UnitOfWorkBuilder unitOfWorkBuilder, SucursalDomainService sucursalDomainService)
        {
            _unitOfWork = unitOfWorkBuilder.BuilderGestionInventarioDbContext();
            _sucursalDomainService = sucursalDomainService;
        }

        public Respuesta<List<ObtenerSucursalDto>> ObtenerSucursales()
        {
            List<ObtenerSucursalDto> sucursales = (from sucursal in _unitOfWork.Repository<Sucursal>().AsQueryable()
                                                   where sucursal.Activo
                                                   select new ObtenerSucursalDto
                                                   {
                                                       SucursalId = sucursal.SucursalId,
                                                       Nombre = sucursal.Nombre,
                                                       Activo = sucursal.Activo,
                                                   }).ToList();
            if (!sucursales.Any())
            {
                return Respuesta.Fault<List<ObtenerSucursalDto>>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            return Respuesta.Success(sucursales, MensajesGlobales.Exito, Codigo.EXITO);
        }
        public Respuesta<AgregarSucursalDto> AgregarSucursal(AgregarSucursalDto sucursalDto)
        {
            string mensaje = string.Empty;
            bool sePuedeAgregarSucursal = _sucursalDomainService.SePuedeAgregarSucursal(sucursalDto, out mensaje);

            if (!sePuedeAgregarSucursal)
            {
                return Respuesta.Fault<AgregarSucursalDto>(mensaje, Codigo.ADVERTENCIA);
            }

            string? nombreSucursal = (from sucursales in _unitOfWork.Repository<Sucursal>().AsQueryable()
                                      where sucursales.Nombre == sucursalDto.Nombre
                                      select sucursales.Nombre).FirstOrDefault();

            if (string.IsNullOrEmpty(nombreSucursal))
            {
                return Respuesta.Fault<AgregarSucursalDto>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            bool validarNombreUnico = _sucursalDomainService.ValidarNombreUnico(nombreSucursal, sucursalDto.Nombre, out mensaje);

            if (!validarNombreUnico)
            {
                return Respuesta.Fault<AgregarSucursalDto>(mensaje, Codigo.ADVERTENCIA);
            }

            Sucursal sucursal = sucursalDto.Adapt<Sucursal>();

            _unitOfWork.Repository<Sucursal>().Add(sucursal);
            _unitOfWork.SaveChanges();

            return Respuesta.Success<AgregarSucursalDto>(null!, mensaje, Codigo.EXITO);
        }

        public Respuesta<ActualizarSucursalDto> ActualizarSucursal(ActualizarSucursalDto sucursalDto)
        {
            string mensaje = string.Empty;
            bool sePuedeActualizar = _sucursalDomainService.SePuedeActualizarSucursal(sucursalDto, out mensaje);

            if (!sePuedeActualizar)
            {
                return Respuesta.Fault<ActualizarSucursalDto>(mensaje, Codigo.ADVERTENCIA);
            }
            Sucursal? sucursal = _unitOfWork.Repository<Sucursal>().AsQueryable()
                .FirstOrDefault(x => x.SucursalId == sucursalDto.SucursalId && x.Activo);

            if (sucursal == null)
            {
                return Respuesta.Fault<ActualizarSucursalDto>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            bool validarNombreUnico = _sucursalDomainService.ValidarNombreUnico(sucursal.Nombre, sucursalDto.Nombre, out mensaje);

            if (!validarNombreUnico)
            {
                return Respuesta.Fault<ActualizarSucursalDto>(mensaje, Codigo.ADVERTENCIA);
            }

            sucursal.Nombre = sucursalDto.Nombre;
            sucursal.FechaModificacion = sucursalDto.FechaModificacion;
            sucursal.UsuarioModificacionId = sucursalDto.UsuarioModificacionId;

            _unitOfWork.Repository<Sucursal>().Update(sucursal);
            _unitOfWork.SaveChanges();

            return Respuesta.Success<ActualizarSucursalDto>(null!, MensajesGlobales.Exito, Codigo.EXITO);

        }

        public Respuesta<Sucursal> CambiarEstadoSucursal(int? sucursalId, int? usuarioId, bool estado)
        {
            string mensaje = string.Empty;
            bool sePuedeCambiarEstadoSucursal = _sucursalDomainService.SePuedeCambiarEstadoSucursal(sucursalId, usuarioId, out mensaje);

            if (!sePuedeCambiarEstadoSucursal)
            {
                return Respuesta.Fault<Sucursal>(mensaje, Codigo.ADVERTENCIA);
            }

            Sucursal? sucursal = _unitOfWork.Repository<Sucursal>().AsQueryable()
                .FirstOrDefault(x => x.SucursalId == sucursalId);

            if (sucursal == null)
            {
                return Respuesta.Fault<Sucursal>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            bool validarEstadoSucursal = _sucursalDomainService.ValidarEstadoSucursal(estado, sucursal.Activo, out mensaje);

            if (!validarEstadoSucursal)
            {
                return Respuesta.Fault<Sucursal>(mensaje, Codigo.ADVERTENCIA);
            }
            sucursal.Activo = estado;
            sucursal.UsuarioModificacionId = usuarioId;
            sucursal.FechaModificacion = DateTime.Now;

            _unitOfWork.Repository<Sucursal>().Update(sucursal);
            _unitOfWork.SaveChanges();

            return Respuesta.Success<Sucursal>(null!, MensajesGlobales.Exito, Codigo.EXITO);
        }
    }
}
