using AdvancedRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdvancedRepository.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        NorthwindEntities db = new NorthwindEntities();
        public void Add(T entity)
        {
             Set().Add(entity);
        }

        public T Bul(int id)
        {
            return Set().Find(id);
        }

        public T Bul(string id)
        {
            return Set().Find(id);
        }

        public void Delete(T entity)
        {
            Set().Remove(entity);
            //db.Entry(entity).State=EntityState.Deleted;
        }

        public IQueryable<T> GetAllList()
        {
            return Set().AsQueryable();
        }

        public List<T> GetList()
        {
            return Set().ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public DbSet<T> Set()
        {
            return db.Set<T>();
        }
    }
}