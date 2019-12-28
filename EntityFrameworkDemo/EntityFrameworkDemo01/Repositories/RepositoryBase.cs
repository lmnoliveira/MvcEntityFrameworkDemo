using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EntityFrameworkDemo01.Repositories.Interfaces;

namespace EntityFrameworkDemo01.Repositories
{
    public abstract class RepositoryBase<T> : DbContext, IRepository<T> where T : class
    {
        public RepositoryBase() : base("name=" +  Connections.EntityFrameworkDemo01ConnName)
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
            Update(t);
            SaveChanges();
        }
    }
}