using LAOZ.CQRS.Commands;

namespace LAOZ.CQRS.Handlers
{
    public interface ICommandHandlerFactory<TId>
    {
        ICommandHandler<T, TId> Handler<T>() where T : BaseCommand<TId>;
    }
}
