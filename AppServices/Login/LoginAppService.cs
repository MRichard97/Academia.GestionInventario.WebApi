using Academia.GestionInventario.WebApi._Infrastructure.Entities.Empleados;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Perfiles;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Usuarios;
using Academia.GestionInventario.WebApi.Models.Login;
using Academia.Transporte.WebApi._Commons.Codigos;
using Academia.Transporte.WebApi._Infrastructure;
using ContabilidadValesCajaChicaApi._Commons.MensajesGlobales;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace Academia.GestionInventario.WebApi.AppServices.Login
{
    public class LoginAppService : ILoginAppService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginAppService(UnitOfWorkBuilder unitOfWorkBuilder)
        {
            _unitOfWork = unitOfWorkBuilder.BuilderGestionInventarioDbContext();
        }

        public Respuesta<LoginDto> Login(string nombreUsuario, string clave)
        {
            List<Usuario> usuarios = _unitOfWork.Repository<Usuario>().AsQueryable().ToList();
            string mensaje = string.Empty;
            bool sePuedeLogear = SePuedeLogear(nombreUsuario, clave, out mensaje, usuarios);

            if (!sePuedeLogear)
            {
                return Respuesta.Fault<LoginDto>(mensaje, Codigo.ADVERTENCIA);
            }

            LoginDto loginDto = (from usuario in _unitOfWork.Repository<Usuario>().AsQueryable()
                                 join perfil in _unitOfWork.Repository<Perfil>().AsQueryable()
                                 on usuario.PerfilId equals perfil.PerfilId
                                 join empleado in _unitOfWork.Repository<Empleado>().AsQueryable()
                                 on usuario.EmpleadoId equals empleado.EmpleadoId
                                 where (usuario.Nombre == nombreUsuario && usuario.Clave == clave)
                                 select new LoginDto
                                 {
                                     UsuarioId = usuario.UsuarioId,
                                     Perfil = perfil.Nombre,
                                     Usuario = usuario.Nombre,
                                     Nombre = empleado.Nombre,
                                     Apellido = empleado.Apellido
                                 }).FirstOrDefault() ?? throw new NullReferenceException();

            return Respuesta.Success(loginDto, mensaje, Codigo.EXITO);
        }

        private bool SePuedeLogear(string nombreCuenta, string calve, out string mensaje, List<Usuario> usuarios)
        {
            if (string.IsNullOrEmpty(nombreCuenta) || string.IsNullOrEmpty(calve))
            {
                mensaje = MensajesGlobales.Data_Null;
                return false;
            }
            if (usuarios == null)
            {
                mensaje = MensajesGlobales.Data_Null;
                return false;
            }
            Usuario usuario = usuarios.FirstOrDefault(u => u.Nombre == nombreCuenta && u.Clave == calve) ?? new Usuario();
            if (string.IsNullOrEmpty(usuario.Nombre) || string.IsNullOrEmpty(usuario.Clave))
            {
                mensaje = MensajesGlobales.Credenciales_Incorrectas;
                return false;
            }
            if (!usuario.Activo)
            {
                mensaje = MensajesGlobales.Usuario_Inactivo;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }

    }
}
