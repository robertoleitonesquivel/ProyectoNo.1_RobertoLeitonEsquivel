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
    public class CrudService<T> : ICrudService<T> where T : class
    {
        private readonly ICrudRepository<T> _crudRepository;

        public CrudService()
        {
            _crudRepository = new CrudRepository<T>();
        }

        public async Task Add(T entidad)
        {
            await _crudRepository.Add(entidad);
        }

        public async Task<List<T>> GetAll()
        {
           return await _crudRepository.GetAll();   
        }
    }
}
