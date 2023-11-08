using Models;
using Repository;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly ColaboradorRepository colaboradorRepository;

        public ColaboradorService()
        {
            colaboradorRepository = new ColaboradorRepository();
        }

        public async Task Add(Colaborador colaborador)
        {
            await colaboradorRepository.Add(colaborador);
        }

        public async Task<Colaborador> GetByCedula(string cedula)
        {
            return await colaboradorRepository.GetByCedula(cedula);
        }
    }
}
