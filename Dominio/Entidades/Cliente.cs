using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Cliente
    {
        public int idCliente { get; set; }
        required
        public string Nombre
        { get; set; }
        required
        public string Apellidos
        { get; set; }
        public DateTime FechaNacimiento { get; set; }
        //public int Edad { get; set; }
    }

}
