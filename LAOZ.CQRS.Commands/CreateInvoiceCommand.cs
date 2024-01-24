namespace LAOZ.CQRS.Commands
{
    public class CreateInvoiceCommand(Guid id, int version) : BaseCommand<Guid>(id, version)
    {
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        // Otros campos relevantes
    }
}
