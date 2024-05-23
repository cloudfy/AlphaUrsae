using AlphaUrsae.Domain.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AlphaUrsae.Domain;

public class DatabaseContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
}
