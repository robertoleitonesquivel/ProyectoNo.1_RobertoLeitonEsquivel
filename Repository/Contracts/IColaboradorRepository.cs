using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IColaboradorRepository
    {
        Task<Colaborador> GetByCedula(string cedula);
        Task Add(Colaborador colaborador);
    }
}
