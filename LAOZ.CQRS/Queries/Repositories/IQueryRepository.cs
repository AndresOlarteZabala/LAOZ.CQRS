namespace LAOZ.CQRS.Repositories.Interfaces
{
    public interface IQueryRepository<T>
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
    }
}
