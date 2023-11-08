using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Herramienta
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Description { get; set; } 
    }
}
