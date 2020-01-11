using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EntityFrameworkDemo.Repositories.Interfaces;

namespace EntityFrameworkDemo.Repositories
{
    public abstract class RepositoryBase<T> : DbContext, IRepository<T> where T : class
    {
        public RepositoryBase()// : base("name=" +  Connections.EntityFrameworkDemoConnName)
        {
        }

        public RepositoryBase(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public virtual T Create(T t)
        {
            var newT = Set<T>().Add(t);
            SaveChanges();
            return newT;
        }

        public virtual void Update(T t)
        {
            Entry(t).State = EntityState.Modified;
            SaveChanges();
        }
    }
}