using Microsoft.AspNetCore.Mvc;
using Dominio.Entidades;

namespace ClientesAPI.Controllers
{
    [Route("RetoTecnico/[Controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly ILogger<Cliente> logger;
        public ClienteController(ILogger<Cliente> logger)
        {
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult CrearCliente(Cliente cliente)
        {
            return Ok(cliente);
        }

        [HttpGet("/ListarClientes")]
        public IEnumerable<Cliente> ListarClientes()
        {
            return new List<Cliente>();
        }

        [HttpGet("/ObtenerCliente/{IdCliente}")]
        public IEnumerable<Cliente> ObtenerCliente(int IdCliente)
        {
            return new List<Cliente>();
        }

        [HttpGet("/ObtenerClientesMayorEdad")]
        public IEnumerable<Cliente> ObtenerClientesMayorEdad()
        {
            return new List<Cliente>();
        }

    }
}
