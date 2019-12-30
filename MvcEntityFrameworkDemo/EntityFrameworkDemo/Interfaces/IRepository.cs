namespace EntityFrameworkDemo.Repositories.Interfaces
{
    public interface IRepository<T> where T:class
    {
        T Create(T t);
        void Update(T t);
    }
}