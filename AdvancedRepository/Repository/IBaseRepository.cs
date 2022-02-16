using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository
{
   public interface IBaseRepository<T> where T:class,new()
    {
        DbSet<T> Set();
        T Bul(int id);
        T Bul(string id);
        void Delete(T entity);
        void Save();
        List<T> GetList();
        void Add(T entity);
        IQueryable<T> GetAllList();
    }
}
