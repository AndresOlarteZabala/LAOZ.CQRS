namespace LAOZ.CQRS.Repositories.DBModels
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        // Otros campos relevantes
    }

}
