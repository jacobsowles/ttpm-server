using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TinyTwoProjectManager.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);

        T Get(Expression<Func<T, bool>> where);

        IEnumerable<T> GetAll();

        T GetById(int id);

        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        void Update(T entity);
    }
}