using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PrestarHerramientaDTO
    {
        public string Cedula { get; set; }
        public int Codigo { get; set; }
        public string FechaPrestamo { get; set; }   
        public string FechaRegreso { get; set; }
    }
}
