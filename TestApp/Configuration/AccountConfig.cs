using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApp.Entities;

namespace TestApp.Configuration
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(f => f.Name)
                .IsRequired();
            builder.HasMany(c => c.Contacts)
                .WithOne(a => a.Account)
                .HasForeignKey(a => a.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(i => i.Incident)
                .WithMany(a => a.Accounts)
                .HasForeignKey(i => i.IncidentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}