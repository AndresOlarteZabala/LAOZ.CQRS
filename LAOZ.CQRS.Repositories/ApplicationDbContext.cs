using LAOZ.CQRS.Repositories.DBModels;
using Microsoft.EntityFrameworkCore;

namespace LAOZ.CQRS.ConsoleApp
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<InvoiceCurrency> InvoiceCurrencies { get; set; }
        public DbSet<InvoiceItemTax> InvoiceItemTaxes { get; set; }
        public DbSet<InvoiceItemDiscount> InvoiceItemDiscounts { get; set; }
        public DbSet<InvoiceItemProduct> InvoiceItemProducts { get; set; }

    }
}