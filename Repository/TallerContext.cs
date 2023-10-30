using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TallerContext:DbContext
    {
        public TallerContext() : base("name=ProyectoNo1Taller") { }

        public DbSet<Herramienta> Herramientas { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
    }
}
