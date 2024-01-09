namespace LAOZ.CQRS.Repositories.Interfaces
{
    public interface ICommandRepository<T>
    {
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        int ExecuteSqlCommand(string sqlCommand);
    }
}
