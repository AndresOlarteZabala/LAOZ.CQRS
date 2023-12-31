using LAOZ.CQRS.Commands;
using LAOZ.CQRS.Queries;
using LAOZ.CQRS.Repositories.Interfaces;

namespace LAOZ.CQRS.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IQueryRepository<GetInvoiceQuery> _queryRepository;
        private readonly ICommandRepository<CreateInvoiceCommand> _commandRepository;

        public InvoiceService(IQueryRepository<GetInvoiceQuery> queryRepository, ICommandRepository<CreateInvoiceCommand> commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        public GetInvoiceQuery CreateInvoice(string customerName, decimal totalAmount)
        {
            var createInvoiceCommand = new CreateInvoiceCommand(Guid.NewGuid(), 0)
            {
                CustomerName = customerName,
                TotalAmount = totalAmount
            };

            var createInvoiceHandler = new Handlers.CreateInvoiceCommandHandler(_commandRepository);
            createInvoiceHandler.Handle(createInvoiceCommand);

            return _queryRepository.GetById(createInvoiceCommand.Id);
        }

        public GetInvoiceQuery GetInvoice(Guid invoiceId)
        {
            var getInvoiceQuery = new GetInvoiceQuery
            {
                InvoiceId = invoiceId
            };

            var getInvoiceHandler = new Handlers.GetInvoiceQueryHandler(_queryRepository);
            return getInvoiceHandler.Handle(getInvoiceQuery);
        }
    }

}
