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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(200)]
        public string Description { get; set; } 
        public List<PrestarHerramienta> PrestarHerramientas { get; set; }   

      

    }
}
