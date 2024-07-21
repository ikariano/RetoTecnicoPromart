using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCliente { get; set; }
        required
        public string Nombre { get; set; }
        required
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        
    }

}
