using Microsoft.AspNetCore.Mvc;
using Dominio.Entidades;
using Aplicacion.Servicios;
using Dominio.Entidades.DTO;

namespace ClientesAPI.Controllers
{
    [Route("RetoTecnico/[Controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly ILogger<Cliente> logger;
        private readonly IClienteServices _clienteServices;
        public ClienteController(ILogger<Cliente> logger, IClienteServices clienteServices)
        {
            this.logger = logger;
            _clienteServices = clienteServices;
        }

        [HttpPost("/CrearCliente")]
        public async Task<IActionResult> CrearCliente([FromBody] ClienteCrearDTO cliente)
        {
            return Ok(await _clienteServices.CrearClienteAsync(cliente));
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
