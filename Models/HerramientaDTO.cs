using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HerramientaDTO
    {
        public int Codigo { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
    }
}
