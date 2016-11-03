using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab4
{
    public class UserRepository<T>: IRepository<T> where T : User
    {
        protected readonly DbContext Context;
        protected DbSet<T> DbSet;

        public UserRepository(DbContext context)
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
    }
}