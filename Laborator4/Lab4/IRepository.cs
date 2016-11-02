using System;
using System.Collections.Generic;

namespace Lab4
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}