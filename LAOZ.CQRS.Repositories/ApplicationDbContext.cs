using LAOZ.CQRS.Repositories.DBModels;
using Microsoft.EntityFrameworkCore;

namespace LAOZ.CQRS.ConsoleApp
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Invoice> Invoices { get; set; }
    }
}