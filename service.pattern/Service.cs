using Dari.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dari.Service
{
    public class Service<T>:IService<T> where T:class
    {
        IRepository<T> repo;
        IUnitOfWork uow;
        public Service(IUnitOfWork _uow)
        {
            uow = _uow;
            repo = uow.GetRepository<T>();
        }
        public void Add(T obj)
        {
            repo.Add(obj);
        }
        public void Update(T obj)
        {
            repo.Update(obj);
        }
        public void Delete(T obj)
        {
            repo.Delete(obj);
        }
        public void Delete(Expression<Func<T, bool>> condition)
        {
            repo.Delete(condition);
        }
        public void Commit()
        {
            repo.Commit();
        }
        public T GetById(string id)
        {
            return repo.GetById(id);
        }
        public T GetById(int id)
        {
            return repo.GetById(id);
        }
        public IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orderBy = null)
        {
            return repo.GetMany(condition, orderBy);
        }
        public IEnumerable<T> GetAll()
        {
            return repo.GetAll();
        }
    }
}
