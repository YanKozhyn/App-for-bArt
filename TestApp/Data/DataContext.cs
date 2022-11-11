using Microsoft.EntityFrameworkCore;
using TestApp.Entities;

namespace TestApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Incident>? Incidents { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<Account>? Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Account>()
                .HasIndex(u => u.Name)
                .IsUnique();

            builder.Entity<Account>()
                .HasMany(c => c.Contacts)
                .WithOne(a => a.Account)
                .HasForeignKey(a => a.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Account>()
                .HasOne(i => i.Incident)
                .WithMany(a => a.Accounts)
                .HasForeignKey(i => i.IncidentId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Contact>()
                .HasOne(a => a.Account)
                .WithMany(c => c.Contacts)
                .HasForeignKey(a => a.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Incident>()
                .HasMany(a => a.Accounts)
                .WithOne(i => i.Incident)
                .HasForeignKey(i => i.IncidentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
