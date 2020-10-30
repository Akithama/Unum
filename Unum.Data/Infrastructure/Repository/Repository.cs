using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unum.Data.Infrastructure.Interfaces;
using Unum.Data.Models;

namespace Unum.Data.Infrastructure.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDBContext Context { get; set; }

        public Repository(ApplicationDBContext _Context)
        {
            this.Context = _Context;
        }
        public void Delete(object id)
        {
            var entity = Context.Set<T>().Find(id);
            Context.Set<T>().Remove(entity);            
        }

        public IEnumerable<T> GetAll()
        {
            return this.Context.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Add(T obj)
        {
            Context.Set<T>().Add(obj);            
        }

        public void Update(T obj)
        {
            this.Context.Entry(obj).State = EntityState.Modified;
        }
    }
}
