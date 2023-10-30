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

        public Int64 Cedula { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(80)]
        public string Apellidos { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }
    }
}
