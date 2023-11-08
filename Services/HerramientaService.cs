using Models;
using Repository;
using Repository.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HerramientaService : IHerramientaService
    {
        private readonly IHerramientaRepository herramientaRepository;

        public HerramientaService() { 
          herramientaRepository = new HerramientaRepository();
        }

        public async Task Add(Herramienta herramienta)
        {
           await herramientaRepository.Add(herramienta);
        }

        public async Task<Herramienta> GetHerramientas(int codigo)
        {
            return await herramientaRepository.GetHerramientas(codigo);
        }

        public async Task Prestar(List<PrestarHerramienta> prestarHerramientas)
        {
            await herramientaRepository.Prestar(prestarHerramientas);
        }
    }
}
