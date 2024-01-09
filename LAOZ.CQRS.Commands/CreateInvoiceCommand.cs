namespace LAOZ.CQRS.Commands
{
    public class CreateInvoiceCommand : BaseCommand
    {
        public CreateInvoiceCommand(Guid id, int version) : base(id, version)
        {
        }
        public CreateInvoiceCommand() : base()
        {
        }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        // Otros campos relevantes
    }
}
