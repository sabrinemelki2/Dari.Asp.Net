﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dari.Data.Infrastructure
{
    public class Repository<T>:IRepository<T> where T:class
    {
        DariContext ctxt;
        IDbSet<T> dbSet;
        public Repository(IDataBaseFactory dbFactory)
        {
            ctxt = dbFactory.Ctxt;
            dbSet = ctxt.Set<T>();
        }
        public void Add(T obj)
        {
            dbSet.Add(obj);
        }
        public void Update(T obj)
        {
            dbSet.Attach(obj);
            ctxt.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(T obj)
        {
            dbSet.Remove(obj);
        }
        public void Delete(Expression<Func<T, bool>> Condition)
        {
            var result = dbSet.Where(Condition);
            if (result!=null)
            foreach (T obj in result)
                dbSet.Remove(obj);
        }
        public void Commit()
        {
            ctxt.SaveChanges();
        }
        public T GetById(string id)
        {
            return dbSet.Find(id);
        }
        public T GetById(int id)
        {
            return dbSet.Find(id);
        }
        public IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orderBy = null)
        {
            if (condition != null)
            {
                if(orderBy != null)
                    return dbSet.Where(condition).OrderBy(orderBy);
                return dbSet.Where(condition);            
            }
            if (orderBy != null)
                return dbSet.OrderBy(orderBy);
            return dbSet.AsEnumerable();
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }
    }
}
