using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GetHerramientaDTO
    {
        public int Codigo { get; set; }
        public string Nombre { get; set;}
        public string FechaPrestamo { get; set; }
        public string FechaRegreso { get;set; }
    }
}
