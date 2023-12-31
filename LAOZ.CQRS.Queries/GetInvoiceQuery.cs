namespace LAOZ.CQRS.Queries
{
    public class GetInvoiceQuery
    {
        public Guid InvoiceId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
