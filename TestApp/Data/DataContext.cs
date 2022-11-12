using Microsoft.EntityFrameworkCore;
using TestApp.Configuration;
using TestApp.Entities;

namespace TestApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Incident> Incidents { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountConfig());
            builder.ApplyConfiguration(new ContactConfig());
            builder.ApplyConfiguration(new IncidentConfig());
        }
    }
}
