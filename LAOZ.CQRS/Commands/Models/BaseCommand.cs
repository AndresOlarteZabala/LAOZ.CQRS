namespace LAOZ.CQRS.Commands
{
    public class BaseCommand : ICommand<Guid>
    {
        public Guid Id { get; private set; }
        public int Version { get; private set; }
        public BaseCommand()
        {
            Id = Guid.NewGuid();
            Version = 1;
        }
        public BaseCommand(Guid id, int version)
        {
            Id = id;
            Version = version;
        }
    }
}
