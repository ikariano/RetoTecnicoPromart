using Aplicacion.Repositorios;
using Aplicacion.Servicios;
using ClientesAPI.Controllers;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entidades.DTO;

namespace ClientesApi.Test.Controllers
{
    public class ClienteControllerTest
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteServices _clienteService;
        private readonly ClienteController _clienteController;
        private readonly ILogger<Cliente> _logger;
        public ClienteControllerTest()
        {
            _clienteRepository = A.Fake<IClienteRepository>();
            _clienteService = A.Fake<IClienteServices>();
            _logger = A.Fake<ILogger<Cliente>>();
            _clienteController = new ClienteController(_logger, _clienteService);
        }

        [Fact]
        public async Task CrearCliente_DeberiaDevolverOk()
        {
            //Arrange
            var clienteCrearDto = new ClienteCrearDTO
            {
                Nombre = "Juan",
                Apellidos = "Pérez",
                FechaNacimiento = new DateTime(1980, 1, 1)
            };

            // Act
            var result = await _clienteController.CrearCliente(clienteCrearDto);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task CrearCliente_DeberiaDevolverError()
        {
            //Arrange

            // Act
            var result = await _clienteController.CrearCliente(null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task CrearCliente_DeberiaDarError_FaltaNombre()
        {
            //Arrange
            var clienteCrearDto = new ClienteCrearDTO
            {
                Nombre = "",
                Apellidos = "Pérez",
                FechaNacimiento = new DateTime(1980, 1, 1)
            };

            // Act
            var result = await _clienteController.CrearCliente(clienteCrearDto);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task CrearCliente_DeberiaDarError_FaltaApellidos()
        {
            //Arrange
            var clienteCrearDto = new ClienteCrearDTO
            {
                Nombre = "Juan",
                Apellidos = "",
                FechaNacimiento = new DateTime(1980, 1, 1)
            };

            // Act
            var result = await _clienteController.CrearCliente(clienteCrearDto);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task CrearCliente_DeberiaDarError_FaltaFechaNacimiento()
        {
            //Arrange
            var clienteCrearDto = new ClienteCrearDTO
            {
                Nombre = "Juan",
                Apellidos = "Perez",
                FechaNacimiento = new DateTime()
            };

            // Act
            var result = await _clienteController.CrearCliente(clienteCrearDto);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task ListarClientes_DeberiaDevolverListaClientes()
        {
            // Arrange
            var listaClientes = new List<ClienteDTO>
            {
                new ClienteDTO { idCliente = 1, Nombre = "Alicia", Apellidos = "Abad", FechaNacimiento = new DateTime(1980, 1, 1), Edad = 44 },
                new ClienteDTO { idCliente = 2, Nombre = "Benjas", Apellidos = "Bernal", FechaNacimiento = new DateTime(1990, 1, 1), Edad = 34 },
                new ClienteDTO { idCliente = 3, Nombre = "Carlos", Apellidos = "Carranza", FechaNacimiento = new DateTime(2000, 1, 1), Edad = 24 }
            };
            A.CallTo(() => _clienteService.ListarClientesAsync()).Returns(Task.FromResult(listaClientes as IEnumerable<ClienteDTO>));

            // Act
            var result = await _clienteController.ListarClientes();

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<List<ClienteDTO>>(result);
            Assert.Equal(3, okResult.Count);
            
        }

        [Fact]
        public async Task ObtenerCliente_DeberiaDevolverCliente()
        {
            // Arrange
            var clienteId = 1;
            var listaClientes = new List<ClienteDTO>
            {
                new ClienteDTO { idCliente = 1, Nombre = "Alicia", Apellidos = "Abad", FechaNacimiento = new DateTime(1980, 1, 1), Edad = 44 }
            };

            A.CallTo(() => _clienteService.ObtenerClienteAsync(clienteId)).Returns(Task.FromResult(listaClientes as IEnumerable<ClienteDTO>));

            // Act
            var result = await _clienteController.ObtenerCliente(clienteId);

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<List<ClienteDTO>>(result);
            Assert.Single(okResult);
            Assert.Equal(clienteId, okResult[0].idCliente);

        }

        [Fact]
        public async Task ObtenerClientesMayorEdad_DeberiaDevolverListaClientes()
        {
            // Arrange
            var listaClientes = new List<ClienteDTO>
            {
                new ClienteDTO { idCliente = 1, Nombre = "Alicia", Apellidos = "Abad", FechaNacimiento = new DateTime(1980, 1, 1), Edad = 44 },
                new ClienteDTO { idCliente = 2, Nombre = "Benjas", Apellidos = "Bernal", FechaNacimiento = new DateTime(1990, 1, 1), Edad = 34 },
                new ClienteDTO { idCliente = 3, Nombre = "Carlos", Apellidos = "Carranza", FechaNacimiento = new DateTime(2000, 1, 1), Edad = 24 }
            };

            A.CallTo(() => _clienteService.ObtenerClientesMayorEdadAsync()).Returns(Task.FromResult(listaClientes as IEnumerable<ClienteDTO>));

            // Act
            var result = await _clienteController.ObtenerClientesMayorEdad();

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<List<ClienteDTO>>(result);
            Assert.Equal(3, okResult.Count);
        }

    }
}
