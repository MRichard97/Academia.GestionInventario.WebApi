using Academia.GestionInventario.WebApi.Models.Login;
using Farsiman.Application.Core.Standard.DTOs;

namespace Academia.GestionInventario.WebApi.AppServices.Login
{
    public interface ILoginAppService
    {
        Respuesta<LoginDto> Login(string nombreUsuario, string clave);
    }
}
