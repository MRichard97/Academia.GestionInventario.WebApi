using Academia.GestionInventario.WebApi._Infrastructure.Entities.Empleados;
using Academia.GestionInventario.WebApi.DomainServices.Empleados;
using Academia.GestionInventario.WebApi.Models.Empleados;
using Academia.Transporte.WebApi._Commons.Codigos;
using Academia.Transporte.WebApi._Infrastructure;
using ContabilidadValesCajaChicaApi._Commons.MensajesGlobales;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using Mapster;

namespace Academia.GestionInventario.WebApi.AppServices.Empleados
{
    public class EmpleadoAppService : IEmpleadoAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly EmpleadoDomainService _empleadoDomainService;
        public EmpleadoAppService(UnitOfWorkBuilder unitOfWorkBuilder, EmpleadoDomainService empleadoDomainService)
        {
            _unitOfWork = unitOfWorkBuilder.BuilderGestionInventarioDbContext();
            _empleadoDomainService = empleadoDomainService;
        }
        public Respuesta<ActualizarEmpleadoDto> ActualizarEmpleado(ActualizarEmpleadoDto empleadoDto)
        {
            string mensaje = string.Empty;
            bool sePuedeActualizar = _empleadoDomainService.SePuedeActualizarEmpleado(empleadoDto, out mensaje);

            if (!sePuedeActualizar)
            {
                return Respuesta.Fault<ActualizarEmpleadoDto>(mensaje, Codigo.ADVERTENCIA);
            }

            Empleado? empleado = _unitOfWork.Repository<Empleado>().AsQueryable()
                .FirstOrDefault(x => x.EmpleadoId == empleadoDto.EmpleadoId && x.Activo);

            if (empleado == null)
            {
                return Respuesta.Fault<ActualizarEmpleadoDto>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            bool validarNombreUnico = _empleadoDomainService.ValidarNombreUnico(empleado.Nombre, empleado.Apellido, empleadoDto.Nombre!, empleadoDto.Apellido!, out mensaje);
            if (!validarNombreUnico)
            {
                return Respuesta.Fault<ActualizarEmpleadoDto>(mensaje, Codigo.ADVERTENCIA);
            }

            empleado.Nombre = empleadoDto.Nombre!;
            empleado.Apellido = empleadoDto.Apellido!;
            empleado.Direccion = empleadoDto.Direccion!;
            empleado.FechaModificacion = empleadoDto.FechaModificacion;
            empleado.UsuarioModificacionId = empleadoDto.UsuarioModificacionId;

            _unitOfWork.Repository<Empleado>().Update(empleado);
            _unitOfWork.SaveChanges();

            return Respuesta.Success<ActualizarEmpleadoDto>(null!, MensajesGlobales.Exito, Codigo.EXITO);
        }

        public Respuesta<AgregarEmpleadoDto> AgregarEmpleado(AgregarEmpleadoDto empleadoDto)
        {
            string mensaje = string.Empty;
            bool sePuedeAgregarSucursal = _empleadoDomainService.SePuedeAgregarEmpleado(empleadoDto, out mensaje);

            if (!sePuedeAgregarSucursal)
            {
                return Respuesta.Fault<AgregarEmpleadoDto>(mensaje, Codigo.ADVERTENCIA);
            }

            string? nombreEmpleado = (from empleados in _unitOfWork.Repository<Empleado>().AsQueryable()
                                      where empleados.Nombre == empleadoDto.Nombre
                                      select empleados.Nombre).FirstOrDefault();
            string? apellidoEmpleado = (from empleados in _unitOfWork.Repository<Empleado>().AsQueryable()
                                        where empleados.Apellido == empleadoDto.Apellido
                                        select empleados.Apellido).FirstOrDefault();

            if (string.IsNullOrEmpty(nombreEmpleado) || string.IsNullOrEmpty(apellidoEmpleado))
            {
                return Respuesta.Fault<AgregarEmpleadoDto>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            bool validarNombreUnico = _empleadoDomainService.ValidarNombreUnico(nombreEmpleado, apellidoEmpleado, empleadoDto.Nombre!, empleadoDto.Apellido!, out mensaje);

            if (!validarNombreUnico)
            {
                return Respuesta.Fault<AgregarEmpleadoDto>(mensaje, Codigo.ADVERTENCIA);
            }

            Empleado empleado = empleadoDto.Adapt<Empleado>();

            _unitOfWork.Repository<Empleado>().Add(empleado);
            _unitOfWork.SaveChanges();

            return Respuesta.Success<AgregarEmpleadoDto>(null!, mensaje, Codigo.EXITO);
        }

        public Respuesta<Empleado> CambiarEstadoEmpleado(int? empleadoId, int? usuarioId, bool estado)
        {
            string mensaje = string.Empty;
            bool sePuedeCambiarEstado = _empleadoDomainService.SePuedeCambiarEstadoEmpleado(empleadoId, usuarioId, out mensaje);

            if (!sePuedeCambiarEstado)
            {
                return Respuesta.Fault<Empleado>(mensaje, Codigo.ADVERTENCIA);
            }

            Empleado? empleado = _unitOfWork.Repository<Empleado>().AsQueryable()
                .FirstOrDefault(x => x.EmpleadoId == empleadoId);

            if (empleado == null)
            {
                return Respuesta.Fault<Empleado>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            bool validarEstadoSucursal = _empleadoDomainService.ValidarEstadoEmpleado(estado, empleado.Activo, out mensaje);

            if (!validarEstadoSucursal)
            {
                return Respuesta.Fault<Empleado>(mensaje, Codigo.ADVERTENCIA);
            }

            empleado.Activo = estado;
            empleado.UsuarioModificacionId = usuarioId;
            empleado.FechaModificacion = DateTime.Now;

            _unitOfWork.Repository<Empleado>().Update(empleado);
            _unitOfWork.SaveChanges();

            return Respuesta.Success<Empleado>(null!, MensajesGlobales.Exito, Codigo.EXITO);
        }

        public Respuesta<List<ObtenerEmpleadoDto>> ObtenerEmpleados()
        {
            List<ObtenerEmpleadoDto> empleados = (from empleado in _unitOfWork.Repository<Empleado>().AsQueryable()
                                                  where empleado.Activo
                                                  select new ObtenerEmpleadoDto
                                                  {
                                                      EmpleadoId = empleado.EmpleadoId,
                                                      Nombre = empleado.Nombre,
                                                      Apellido = empleado.Apellido,
                                                      Direccion = empleado.Direccion,
                                                      Activo = empleado.Activo
                                                  }).ToList();
            if (!empleados.Any())
            {
                return Respuesta.Fault<List<ObtenerEmpleadoDto>>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            return Respuesta.Success(empleados, MensajesGlobales.Exito, Codigo.EXITO);
        }
    }
}
