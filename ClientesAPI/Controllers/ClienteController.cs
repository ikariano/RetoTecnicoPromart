using Microsoft.AspNetCore.Mvc;
using Dominio.Entidades;
using Aplicacion.Servicios;
using Dominio.Entidades.DTO;
using Microsoft.IdentityModel.Tokens;

namespace ClientesAPI.Controllers
{
    [Route("RetoTecnico/[Controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly ILogger<Cliente> _logger;
        private readonly IClienteServices _clienteServices;
        public ClienteController(ILogger<Cliente> logger, IClienteServices clienteServices)
        {
            _logger = logger;
            _clienteServices = clienteServices;
        }

        [HttpPost("/CrearCliente")]
        public async Task<IActionResult> CrearCliente([FromBody] ClienteCrearDTO cliente)
        {
            
            if (cliente == null)
            {
                _logger.LogInformation("Debe enviar un objeto válido.. ejemplo: {\"Nombre\": \"Juan\",  \"Apellidos\": \"Pérez\",  \"FechaNacimiento\": \"2024-07-21\"}", "");
                return BadRequest();
            }

            if (string.IsNullOrEmpty(cliente.Nombre))
            {
                _logger.LogInformation("No puede enviar el Nombre del cliente vacio.");
                return BadRequest();
            }

            if (string.IsNullOrEmpty(cliente.Apellidos))
            {
                _logger.LogInformation("No puede enviar los apellidos del cliente vacio.");
                return BadRequest();
            }

            if (cliente.FechaNacimiento == DateTime.MinValue || string.IsNullOrEmpty(cliente.FechaNacimiento.ToString()))
            {
                _logger.LogInformation("la fecha de nacimiento no es una fecha válida.");
                return BadRequest();
            }

            await _clienteServices.CrearClienteAsync(cliente);
            return Ok();
            
        }

        [HttpGet("/ListarClientes")]
        public async Task<IEnumerable<ClienteDTO>> ListarClientes()
        {
            return await _clienteServices.ListarClientesAsync();
        }

        [HttpGet("/ObtenerCliente/{IdCliente}")]
        public async Task<IEnumerable<ClienteDTO>> ObtenerCliente(int IdCliente)
        {
            return await _clienteServices.ObtenerClienteAsync(IdCliente);
        }

        [HttpGet("/ObtenerClientesMayorEdad")]
        public async Task<IEnumerable<ClienteDTO>> ObtenerClientesMayorEdad()
        {
            return await _clienteServices.ObtenerClientesMayorEdadAsync();
        }

    }
}
