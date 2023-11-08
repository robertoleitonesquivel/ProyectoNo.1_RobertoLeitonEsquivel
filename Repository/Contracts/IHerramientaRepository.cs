using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IHerramientaRepository 
    {
        Task<Herramienta> GetHerramientas(int codigo);
        Task Prestar(List<PrestarHerramienta> prestarHerramientas);
        Task Add(Herramienta herramienta);
    }
}
