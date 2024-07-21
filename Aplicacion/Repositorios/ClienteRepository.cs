using Aplicacion.Contexto;
using Dominio.Entidades;
using Dominio.Entidades.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AplicacionContext _context;

        public ClienteRepository(AplicacionContext context)
        {
            _context = context;
        }

        public async Task<Cliente> CrearClienteAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;

        }

        public async Task<IEnumerable<ClienteDTO>> ListarClientesAsync()
        {
            var clientes = await _context.Clientes.Select(cliente =>
                new ClienteDTO
                {
                    idCliente = cliente.idCliente,
                    Nombre = cliente.Nombre,
                    Apellidos = cliente.Apellidos,
                    FechaNacimiento = cliente.FechaNacimiento,
                    Edad = CalcularEdad(cliente.FechaNacimiento)
                }
            ).ToListAsync();

            return clientes ?? new List<ClienteDTO>();

        }

        public async Task<IEnumerable<ClienteDTO>> ObtenerClienteAsync(int IdCliente)
        {
            List<ClienteDTO> clientes = new List<ClienteDTO>();
            
            var clienteEncontrado = await _context.Clientes.FindAsync(IdCliente);
            if (clienteEncontrado == null)
            {
                return clientes;
            }
            else
            {
                clientes.Add(new ClienteDTO { 
                    idCliente = clienteEncontrado.idCliente,
                    Nombre = clienteEncontrado.Nombre,
                    Apellidos = clienteEncontrado.Apellidos,
                    FechaNacimiento = clienteEncontrado.FechaNacimiento,
                    Edad = CalcularEdad(clienteEncontrado.FechaNacimiento)

                });
            }
            
            return clientes;
        }

        public async Task<IEnumerable<ClienteDTO>> ObtenerClientesMayorEdadAsync()
        {
            var clientesMayorEdad = await _context.Clientes.Select(cliente =>
                new ClienteDTO
                {
                    idCliente = cliente.idCliente,
                    Nombre = cliente.Nombre,
                    Apellidos = cliente.Apellidos,
                    FechaNacimiento = cliente.FechaNacimiento,
                    Edad = CalcularEdad(cliente.FechaNacimiento)
                }
            ).ToListAsync();



            return clientesMayorEdad.OrderByDescending(c => c.Edad).Take(3).ToList()
              ?? new List<ClienteDTO>();
        }

        static int CalcularEdad(DateTime FechaNacimiento)
        {
            DateTime fechaActual = DateTime.Today;

            int edad = fechaActual.Year - FechaNacimiento.Year;

            if (FechaNacimiento.Date > fechaActual.AddYears(-edad))
            {
                edad--;
            }

            return edad;
        }
    }
}
