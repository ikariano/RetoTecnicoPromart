using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Aplicacion.Contexto
{
    public class AplicacionContext: DbContext
    {

        public AplicacionContext(DbContextOptions<AplicacionContext> options) : base(options)
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
