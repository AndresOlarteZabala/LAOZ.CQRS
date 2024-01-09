namespace LAOZ.CQRS.Commands
{
    public interface ICommand<T>
    {
        T Id { get; }
    }
}
