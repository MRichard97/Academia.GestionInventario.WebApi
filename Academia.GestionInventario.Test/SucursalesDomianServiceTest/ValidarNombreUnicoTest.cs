using Academia.GestionInventario.WebApi.DomainServices.Sucursales;
using ContabilidadValesCajaChicaApi._Commons.MensajesGlobales;

namespace Academia.GestionInventario.Test.SucursalesDomianServiceTest
{
    public class ValidarNombreUnicoTest
    {
        [Fact]
        public void ValidarNombreUnico_DeberiaDevolverFalseCuandoNombresSonIguales()
        {
            // Arrange
            SucursalDomainService sucursalDomainService = new SucursalDomainService();
            string mensaje;

            // Act
            var resultado = sucursalDomainService.ValidarNombreUnico("Nombre1", "Nombre1", out mensaje);

            // Assert
            Assert.False(resultado);
            Assert.Equal(MensajesGlobales.Nombre_Ya_Existe, mensaje);
        }

        [Fact]
        public void ValidarNombreUnico_DeberiaDevolverTrueCuandoNombresSonDiferentes()
        {
            // Arrange
            SucursalDomainService sucursalDomainService = new SucursalDomainService();
            string mensaje;

            // Act
            var resultado = sucursalDomainService.ValidarNombreUnico("Nombre1", "Nombre2", out mensaje);

            // Assert
            Assert.True(resultado);
            Assert.Equal(MensajesGlobales.Exito, mensaje);
        }
    }
}
