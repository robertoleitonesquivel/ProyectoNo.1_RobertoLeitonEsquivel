using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ColaboradorDTO
    {

        [Required]
        [RegularExpression(@"^\d{9}$")]
        public Int64 Cedula { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(80)]
        public string Apellidos { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required]
        public string Estado { get; set; }
    }
}
