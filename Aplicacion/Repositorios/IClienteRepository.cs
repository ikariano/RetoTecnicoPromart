using Dominio.Entidades;
using Dominio.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Repositorios
{
    public interface IClienteRepository
    {
        Task<Cliente> CrearClienteAsync(ClienteCrearDTO cliente);
        Task<IEnumerable<ClienteDTO>> ListarClientesAsync();
        Task<IEnumerable<ClienteDTO>> ObtenerClienteAsync(int IdCliente);
        Task<IEnumerable<ClienteDTO>> ObtenerClientesMayorEdadAsync();

    }
}
