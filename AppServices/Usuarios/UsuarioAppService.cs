using Academia.GestionInventario.WebApi._Infrastructure.Entities.Empleados;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Perfiles;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Usuarios;
using Academia.GestionInventario.WebApi.DomainServices.Usuarios;
using Academia.GestionInventario.WebApi.Models.Usuarios;
using Academia.Transporte.WebApi._Commons.Codigos;
using Academia.Transporte.WebApi._Infrastructure;
using ContabilidadValesCajaChicaApi._Commons.MensajesGlobales;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using Mapster;

namespace Academia.GestionInventario.WebApi.AppServices.Usuarios
{
    public class UsuarioAppService : IUsuarioAppServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UsuarioDomainService _usuarioDomainService;
        public UsuarioAppService(UnitOfWorkBuilder unitOfWorkBuilder, UsuarioDomainService usuarioDomainService)
        {
            _unitOfWork = unitOfWorkBuilder.BuilderGestionInventarioDbContext();
            _usuarioDomainService = usuarioDomainService;
        }
        public Respuesta<ActualizarUsuarioDto> ActualizarUsuario(ActualizarUsuarioDto usuarioDto)
        {
            string mensaje = string.Empty;
            bool sePuedeActualizar = _usuarioDomainService.SePuedeActualizarUsuario(usuarioDto, out mensaje);

            if (!sePuedeActualizar)
            {
                return Respuesta.Fault<ActualizarUsuarioDto>(mensaje, Codigo.ADVERTENCIA);
            }

            Usuario? usuario = _unitOfWork.Repository<Usuario>().AsQueryable()
                .FirstOrDefault(x => x.UsuarioId == usuarioDto.UsuarioId && x.Activo);

            if (usuario == null)
            {
                return Respuesta.Fault<ActualizarUsuarioDto>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            bool validarUsuarioUnico = _usuarioDomainService.ValidarUsuarioUnico(usuario.Nombre!, usuarioDto.Nombre!, out mensaje);
            if (!validarUsuarioUnico)
            {
                return Respuesta.Fault<ActualizarUsuarioDto>(mensaje, Codigo.ADVERTENCIA);
            }

            usuario.UsuarioId = usuarioDto.UsuarioId;
            usuario.Nombre = usuarioDto.Nombre;
            usuario.Clave = usuarioDto.Clave;
            usuario.EmpleadoId = usuarioDto.EmpleadoId;
            usuario.PerfilId = usuarioDto.PerfilId;
            usuario.FechaModificacion = usuarioDto.FechaModificacion;
            usuario.UsuarioModificacionId = usuarioDto.UsuarioModificacionId;

            _unitOfWork.Repository<Usuario>().Update(usuario);
            _unitOfWork.SaveChanges();

            return Respuesta.Success<ActualizarUsuarioDto>(null!, mensaje, Codigo.EXITO);
        }

        public Respuesta<AgregarUsuarioDto> AgregarUsuarios(AgregarUsuarioDto usuarioDto)
        {
            string mensaje = string.Empty;
            bool sePuedeAgregar = _usuarioDomainService.SePuedeAgregarUsuario(usuarioDto, out mensaje);

            if (!sePuedeAgregar)
            {
                return Respuesta.Fault<AgregarUsuarioDto>(mensaje, Codigo.ADVERTENCIA);
            }

            string? usuarioUnico = (from usuarios in _unitOfWork.Repository<Usuario>().AsQueryable()
                                    where usuarios.Nombre == usuarioDto.Nombre
                                    select usuarios.Nombre).FirstOrDefault();

            if (string.IsNullOrEmpty(usuarioUnico))
            {
                return Respuesta.Fault<AgregarUsuarioDto>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            bool validarUsuarioUnico = _usuarioDomainService.ValidarUsuarioUnico(usuarioUnico, usuarioDto.Nombre!, out mensaje);

            if (!validarUsuarioUnico)
            {
                return Respuesta.Fault<AgregarUsuarioDto>(mensaje, Codigo.ADVERTENCIA);
            }

            Usuario usuario = usuarioDto.Adapt<Usuario>();

            _unitOfWork.Repository<Usuario>().Add(usuario);
            _unitOfWork.SaveChanges();

            return Respuesta.Success<AgregarUsuarioDto>(null!, mensaje, Codigo.EXITO);
        }

        public Respuesta<Usuario> CambiarEstadoUsuario(int? usuarioId, int? usuarioActualizaId, bool estado)
        {
            string mensaje = string.Empty;
            bool sePuedeCambiarEstado = _usuarioDomainService.SePuedeCambiarEstadoUsuario(usuarioId, usuarioId, out mensaje);

            if (!sePuedeCambiarEstado)
            {
                return Respuesta.Fault<Usuario>(mensaje, Codigo.ADVERTENCIA);
            }

            Usuario? usuario = _unitOfWork.Repository<Usuario>().AsQueryable()
                .FirstOrDefault(x => x.UsuarioId == usuarioId);

            if (usuario == null)
            {
                return Respuesta.Fault<Usuario>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            bool validarEstadoSucursal = _usuarioDomainService.ValidarEstadoUsuario(estado, usuario.Activo, out mensaje);

            if (!validarEstadoSucursal)
            {
                return Respuesta.Fault<Usuario>(mensaje, Codigo.ADVERTENCIA);
            }

            usuario.Activo = estado;
            usuario.UsuarioModificacionId = usuarioId;
            usuario.FechaModificacion = DateTime.Now;

            _unitOfWork.Repository<Usuario>().Update(usuario);
            _unitOfWork.SaveChanges();

            return Respuesta.Success<Usuario>(null!, MensajesGlobales.Exito, Codigo.EXITO);
        }

        public Respuesta<List<ObtenerUsuarioDto>> ObtenerUsuarios()
        {
            List<ObtenerUsuarioDto> usuarios = (from Usuario in _unitOfWork.Repository<Usuario>().AsQueryable()
                                                join empleado in _unitOfWork.Repository<Empleado>().AsQueryable()
                                                on Usuario.EmpleadoId equals empleado.EmpleadoId
                                                join perfil in _unitOfWork.Repository<Perfil>().AsQueryable()
                                                on Usuario.PerfilId equals perfil.PerfilId
                                                where Usuario.Activo
                                                select new ObtenerUsuarioDto
                                                {
                                                    UsuarioId = Usuario.UsuarioId,
                                                    Nombre = Usuario.Nombre,
                                                    NombreEmpleado= $"{empleado.Nombre} {empleado.Apellido}",
                                                    EmpleadoId = Usuario.EmpleadoId,
                                                    PerfilId = Usuario.PerfilId,
                                                    Perfil = perfil.Nombre,
                                                    Activo = Usuario.Activo
                                                }).ToList();
            if (!usuarios.Any())
            {
                return Respuesta.Fault<List<ObtenerUsuarioDto>>(MensajesGlobales.Data_No_Encontrada, Codigo.ADVERTENCIA);
            }

            return Respuesta.Success(usuarios, MensajesGlobales.Exito, Codigo.EXITO);
        }
    }
}
