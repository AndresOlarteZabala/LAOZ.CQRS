namespace LAOZ.CQRS.Commands
{
    public class BaseCommand : ICommand
    {
        public Guid Id { get; private set; }
        public int Version { get; private set; }
        public BaseCommand(Guid id, int version)
        {
            Id = id;
            Version = version;
        }
    }
}
