using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PrestarHerramientaDTO
    {
        [Required]
        public string Cedula { get; set; }
        [Required]
        public int Codigo { get; set; }
        [Required]
        public string FechaPrestamo { get; set; }
        [Required]
        public string FechaRegreso { get; set; }
    }
}
