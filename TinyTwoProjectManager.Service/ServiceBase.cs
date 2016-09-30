using System;
using System.Linq;
using System.Linq.Expressions;
using TinyTwoProjectManager.Data.Infrastructure;
using TinyTwoProjectManager.Data.Repositories;
using TinyTwoProjectManager.Models;

namespace TinyTwoProjectManager.Services
{
    public abstract class ServiceBase<T1, T2> where T1 : Entity where T2 : IRepository<T1>
    {
        protected readonly T2 Repository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceBase(T2 repository, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Create(T1 entity)
        {
            Repository.Create(entity);
        }

        public void Delete(T1 entity)
        {
            Repository.Delete(entity);
        }

        public void DeleteMany(Expression<Func<T1, bool>> where)
        {
            Repository.DeleteMany(where);
        }   

        public T1 Get(int id)
        {
            return Repository.Get(id);
        }

        public IQueryable<T1> GetAll()
        {
            return Repository.GetAll();
        }

        public T1 GetFirst(Expression<Func<T1, bool>> where)
        {
            return Repository.GetFirst(where);
        }

        public IQueryable<T1> GetMany(Expression<Func<T1, bool>> where)
        {
            return Repository.GetMany(where);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(T1 entity)
        {
            Repository.Update(entity);
        }
    }
}