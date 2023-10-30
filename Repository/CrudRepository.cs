using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        public async Task Add(T entidad)
        {
            using (var conn = new TallerContext())
            {
                conn.Set<T>().Add(entidad);
                await conn.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAll()
        {
            using (var conn = new TallerContext())
            {
                return await conn.Set<T>().ToListAsync();
               
            }
        }
    }
    
  
}
