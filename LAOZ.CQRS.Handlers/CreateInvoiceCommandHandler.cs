using LAOZ.CQRS.Commands;
using LAOZ.CQRS.Repositories.Interfaces;

namespace LAOZ.CQRS.Handlers
{
    public class CreateInvoiceCommandHandler : ICommandHandler<CreateInvoiceCommand> 
    {
        private readonly ICommandRepository<CreateInvoiceCommand> _repository;

        public CreateInvoiceCommandHandler(ICommandRepository<CreateInvoiceCommand> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateInvoiceCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            if (_repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }

            var invoice = new CreateInvoiceCommand(Guid.NewGuid(), 1)
            {
                CustomerName = command.CustomerName,
                TotalAmount = command.TotalAmount
            };

            _repository.Add(invoice);
        }
    }
}
