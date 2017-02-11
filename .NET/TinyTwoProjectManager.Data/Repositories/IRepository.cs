using System;
using System.Linq;
using System.Linq.Expressions;

namespace TinyTwoProjectManager.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);

        void Delete(T entity);

        void DeleteMany(Expression<Func<T, bool>> where);

        T GetFirst(Expression<Func<T, bool>> where);

        IQueryable<T> GetAll();

        T Get(int id);

        IQueryable<T> GetMany(Expression<Func<T, bool>> where);

        void Update(T entity);
    }
}