using CvProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CvProject.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        CvDatabaseEntities entities = new CvDatabaseEntities();

        public List<T> List()
        {
            return entities.Set<T>().ToList();
        }

        public void Add(T t)
        {
            entities.Set<T>().Add(t);
            entities.SaveChanges();
        }

        public void Delete(T t)
        {
            entities.Set<T>().Remove(t);
            entities.SaveChanges();
        }

        public T GetById(int id)
        {
            return entities.Set<T>().Find(id);

        }

        public void Update(T t)
        {
            entities.SaveChanges();
        }
    }
}