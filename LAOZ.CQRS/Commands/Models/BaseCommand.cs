namespace LAOZ.CQRS.Commands
{
    public class BaseCommand<T>(T id, int version) : ICommand<T>
    {
        public T Id { get; private set; } = id;
        public int Version { get; private set; } = version;
    }
}
