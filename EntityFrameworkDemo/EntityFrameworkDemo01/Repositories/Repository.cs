using System.Data.Entity;
using EntityFrameworkDemo01.Repositories.Interfaces;

namespace EntityFrameworkDemo01.Repositories
{
    public abstract class Repository<T> : DbContext, IRepository<T> where T : class
    {
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