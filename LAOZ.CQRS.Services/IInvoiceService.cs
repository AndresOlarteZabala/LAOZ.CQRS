using LAOZ.CQRS.Queries;

namespace LAOZ.CQRS.Services
{
    public interface IInvoiceService
    {
        GetInvoiceQuery CreateInvoice(string customerName, decimal totalAmount);
        GetInvoiceQuery GetInvoice(Guid invoiceId);
    }
}
