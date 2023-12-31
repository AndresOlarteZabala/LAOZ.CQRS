using LAOZ.CQRS.Queries;
using LAOZ.CQRS.Repositories.Interfaces;

namespace LAOZ.CQRS.Handlers
{
    public class GetInvoiceQueryHandler
    {
        private readonly IQueryRepository<GetInvoiceQuery> _repository;

        public GetInvoiceQueryHandler(IQueryRepository<GetInvoiceQuery> repository)
        {
            _repository = repository;
        }

        public GetInvoiceQuery Handle(GetInvoiceQuery query)
        {
            return _repository.GetById(query.InvoiceId);
        }
    }
}
