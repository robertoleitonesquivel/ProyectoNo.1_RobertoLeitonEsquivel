using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IHerramientaService
    {
        Task<Herramienta> GetHerramientas(int codigo);
        Task Prestar(List<PrestarHerramienta> prestarHerramientas);
        Task Add(Herramienta herramienta);
        Task<List<GetHerramientaDTO>> GetHerramientasByColaborador(string cedula);
        Task Devolucion(List<GetHerramientaDTO> devoluciones);
        Task<int> GetHerramientaPrestada(int codigo);
    }
}
