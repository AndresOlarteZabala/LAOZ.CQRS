namespace LAOZ.CQRS.Repositories.Interfaces
{
    public interface ICommandRepository<T>
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
