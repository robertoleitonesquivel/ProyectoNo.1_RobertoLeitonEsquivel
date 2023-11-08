using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PrestarHerramienta
    {  
        public int Id { get; set; }
        [ForeignKey("Colaborador")]
        public string Cedula { get; set; }
        public Colaborador Colaborador { get; set; }
        [ForeignKey("Herramienta")]
        public int Codigo { get; set; }
        public Herramienta Herramienta { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaRegreso { get; set; }
    }
}
