using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lab4
{
    public class CustomerRepository<T> : IRepository<T> where T : Customer
    {
        protected readonly DbContext Context;
        protected DbSet<T> DbSet;

        public CustomerRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet;
        }

        public void Add(T entity)
        {
            //  DbSet.Add(entity);
            DbSet.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
            Context.SaveChanges();
        }

        public T FindById(Guid id)
        {
            var result = (from r in DbSet where r.Id == id select r).FirstOrDefault();
            return result;
        }
    }

}