namespace LAOZ.CQRS.Repositories.DBModels
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalDiscount { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyDescription { get; set; }
        public string CurrencyPrice { get; set; }
    }

    public class Tax
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Percentage { get; set; }
    }

    public class Discount
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Percentage { get; set; }
    }

    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class InvoiceItem
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid ProductId { get; set; }
        public Guid TaxId { get; set; }
        public Guid DiscountId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TaxPercentage { get; set; }
        public decimal DiscountPercentage { get; set; }
    }

    public class Currency
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class InvoiceCurrency
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid CurrencyId { get; set; }
        public decimal Price { get; set; }
    }

    public class InvoiceTax
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid TaxId { get; set; }
        public decimal Percentage { get; set; }
    }

    public class InvoiceDiscount
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid DiscountId { get; set; }
        public decimal Percentage { get; set; }
    }

    public class InvoiceProduct
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class InvoiceItemTax
    {
        public Guid Id { get; set; }
        public Guid InvoiceItemId { get; set; }
        public Guid TaxId { get; set; }
        public decimal Percentage { get; set; }
    }

    public class InvoiceItemDiscount
    {
        public Guid Id { get; set; }
        public Guid InvoiceItemId { get; set; }
        public Guid DiscountId { get; set; }
        public decimal Percentage { get; set; }
    }

    public class InvoiceItemProduct
    {
        public Guid Id { get; set; }
        public Guid InvoiceItemId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
