using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICrudService<T> where T : class
    {
        Task Add(T entidad);
        Task<List<T>> GetAll();
    }
}
