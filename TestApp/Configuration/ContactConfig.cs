using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApp.Entities;

namespace TestApp.Configuration
{
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(f => f.FirstName)
                .IsRequired();

            builder.Property(l => l.LastName)
                .IsRequired();

            builder.Property(e => e.Email)
                .IsRequired();

            builder.HasOne(a => a.Account)
                .WithMany(c => c.Contacts)
                .HasForeignKey(a => a.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}