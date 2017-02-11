using System;
using System.Linq;
using System.Linq.Expressions;

namespace TinyTwoProjectManager.Services
{
    public interface IService<T> where T : class
    {
        void Create(T entity);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);

        T Get(Expression<Func<T, bool>> where);

        IQueryable<T> GetAll();

        T GetById(int id);

        IQueryable<T> GetMany(Expression<Func<T, bool>> where);

        void Save();

        void Update(T entity);
    }
}