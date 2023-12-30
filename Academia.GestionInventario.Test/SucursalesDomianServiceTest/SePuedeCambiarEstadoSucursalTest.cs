using Academia.GestionInventario.WebApi.DomainServices.Sucursales;
using ContabilidadValesCajaChicaApi._Commons.MensajesGlobales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.GestionInventario.Test.SucursalesDomianServiceTest
{
    public class SePuedeCambiarEstadoSucursalTest
    {
        [Fact]
        public void SePuedeCambiarEstadoSucursal_DeberiaDevolverFalseCuandoSucursalNoExiste()
        {
            // Arrange
            SucursalDomainService sucursalDomainService = new SucursalDomainService();
            string mensaje;

            // Act
            var resultado = sucursalDomainService.SePuedeCambiarEstadoSucursal(null, 1, out mensaje);

            // Assert
            Assert.False(resultado);
            Assert.Equal(MensajesGlobales.Sucursal_No_Existe, mensaje);
        }

        [Fact]
        public void SePuedeCambiarEstadoSucursal_DeberiaDevolverFalseCuandoUsuarioNoExiste()
        {
            // Arrange
            SucursalDomainService sucursalDomainService = new SucursalDomainService();
            string mensaje;

            // Act
            var resultado = sucursalDomainService.SePuedeCambiarEstadoSucursal(1, null, out mensaje);

            // Assert
            Assert.False(resultado);
            Assert.Equal(MensajesGlobales.Usuario_No_Existe, mensaje);
        }

        [Fact]
        public void SePuedeCambiarEstadoSucursal_DeberiaDevolverFalseCuandoSucursalIdMenorOIgualACero()
        {
            // Arrange
            SucursalDomainService sucursalDomainService = new SucursalDomainService();
            string mensaje;

            // Act
            var resultado = sucursalDomainService.SePuedeCambiarEstadoSucursal(0, 1, out mensaje);

            // Assert
            Assert.False(resultado);
            Assert.Equal(MensajesGlobales.Sucursal_No_Existe, mensaje);
        }

        [Fact]
        public void SePuedeCambiarEstadoSucursal_DeberiaDevolverFalseCuandoUsuarioIdMenorOIgualACero()
        {
            // Arrange
            SucursalDomainService sucursalDomainService = new SucursalDomainService();
            string mensaje;

            // Act
            var resultado = sucursalDomainService.SePuedeCambiarEstadoSucursal(1, 0, out mensaje);

            // Assert
            Assert.False(resultado);
            Assert.Equal(MensajesGlobales.Usuario_No_Existe, mensaje);
        }

        [Fact]
        public void SePuedeCambiarEstadoSucursal_DeberiaDevolverTrueCuandoParametrosSonValidos()
        {
            // Arrange
            SucursalDomainService sucursalDomainService = new SucursalDomainService();
            string mensaje;

            // Act
            var resultado = sucursalDomainService.SePuedeCambiarEstadoSucursal(1, 2, out mensaje);

            // Assert
            Assert.True(resultado);
            Assert.Equal(MensajesGlobales.Exito, mensaje);
        }
    }
}
