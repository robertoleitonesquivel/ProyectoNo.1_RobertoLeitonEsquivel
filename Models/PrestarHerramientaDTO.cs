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
        public DateTime FechaPrestamo { get; set; } = DateTime.Now;
        [Required]
        public DateTime FechaRegreso { get; set; } = DateTime.Now;
    }
}
