using Acme.WebApi.Docker.Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Acme.WebApi.Docker.Demo.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) {

            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (databaseCreator != null)
            {
                if (!databaseCreator.CanConnect())
                {
                    databaseCreator.Create();
                }
                if (!databaseCreator.HasTables())
                {
                    databaseCreator.CreateTables();
                }
            }
        }

        public ApplicationDbContext() { }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerId = Guid.Parse( "D9875573-E71F-4A83-90EC-00C2A0F68D4D"), CustomerName="Rajesh K", Address="Jubilee Hills, Hyderabad", Description="N/A" });
        }

        public DbSet<Acme.WebApi.Docker.Demo.Models.Order> Order { get; set; } = default!;


    }
}
