namespace LAOZ.CQRS.Queries
{
    public class GetInvoiceQuery
    {
        public Guid InvoiceId { get; set; }
        public required string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

