using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.DTO
{
    public class ClienteCrearDTO
    {
        required
        public string Nombre { get; set; }
        required
        public string Apellidos { get; set; }
        required
        public DateTime FechaNacimiento { get; set; }
    }
}
