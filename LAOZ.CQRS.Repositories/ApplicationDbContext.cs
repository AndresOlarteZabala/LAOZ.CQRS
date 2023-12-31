using LAOZ.CQRS.Repositories.DBModels;
using Microsoft.EntityFrameworkCore;

namespace LAOZ.CQRS.ConsoleApp
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }

        // Constructor con opción de configuración
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}