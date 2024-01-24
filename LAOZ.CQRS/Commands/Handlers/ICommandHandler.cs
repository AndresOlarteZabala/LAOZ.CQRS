using LAOZ.CQRS.Commands;

namespace LAOZ.CQRS.Handlers
{
    public interface ICommandHandler<TCommand, TId> where TCommand : BaseCommand<TId>
    {
        void Handle(TCommand command);
    }
}
