using Aplicacion.Repositorios;
using Dominio.Entidades;
using Dominio.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<Cliente> CrearClienteAsync(Cliente cliente)
        {
            return await _clienteRepository.CrearClienteAsync(cliente);
        }

        public async Task<IEnumerable<ClienteDTO>> ListarClientesAsync()
        {
            return  await _clienteRepository.ListarClientesAsync();
        }

        public async Task<IEnumerable<ClienteDTO>> ObtenerClienteAsync(int IdCliente)
        {
            return await _clienteRepository.ObtenerClienteAsync();
        }

        public async Task<IEnumerable<ClienteDTO>> ObtenerClientesMayorEdadAsync()
        {
            return await _clienteRepository.ObtenerClientesMayorEdadAsync();
        }
    }
}
