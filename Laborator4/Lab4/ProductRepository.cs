using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace Lab4
{
    public class ProductRepository<T> : IRepository<T> where T : Product
    {
        protected readonly DbContext Context;
        protected DbSet<T> DbSet;

        public ProductRepository(DbContext context)
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

        public T FindByPrice(double price)
        {
            var result = (from r in DbSet where r.Price == price select r).FirstOrDefault();
            return result;
        }
    }
}