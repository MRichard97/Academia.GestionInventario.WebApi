using Academia.GestionInventario.WebApi.DomainServices.Sucursales;
using ContabilidadValesCajaChicaApi._Commons.MensajesGlobales;

namespace Academia.GestionInventario.Test.SucursalesDomianServiceTest
{
    public class ValidarEstadoSucursalTest
    {
        [Fact]
        public void ValidarEstadoSucursal_DeberiaDevolverFalseCuandoEstadosSonIguales()
        {
            // Arrange
            SucursalDomainService sucursalDomainService = new SucursalDomainService();
            string mensaje;

            // Act
            var resultado = sucursalDomainService.ValidarEstadoSucursal(true, true, out mensaje);

            // Assert
            Assert.False(resultado);
            Assert.Equal(MensajesGlobales.Estado_Igual, mensaje);
        }

        [Fact]
        public void ValidarEstadoSucursal_DeberiaDevolverTrueCuandoEstadosSonDiferentes()
        {
            // Arrange
            SucursalDomainService sucursalDomainService = new SucursalDomainService();
            string mensaje;

            // Act
            var resultado = sucursalDomainService.ValidarEstadoSucursal(true, false, out mensaje);

            // Assert
            Assert.True(resultado);
            Assert.Equal(MensajesGlobales.Exito, mensaje);
        }
    }
}
