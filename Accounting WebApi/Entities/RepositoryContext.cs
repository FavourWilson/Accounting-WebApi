using Accounting_WebApi.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounting_WebApi.Entities
{
    public class RepositoryContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public RepositoryContext(DbContextOptions options):base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

        public DbSet<Staffs> Staffs { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
    }
}
