using LAOZ.CQRS.Commands;

namespace LAOZ.CQRS.Handlers
{
    public interface ICommandHandler<TCommand> where TCommand : BaseCommand
    {
        void Handle(TCommand command);
    }
}
