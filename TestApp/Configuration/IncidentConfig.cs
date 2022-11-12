using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApp.Entities;

namespace TestApp.Configuration
{
public class IncidentConfig : IEntityTypeConfiguration<Incident>
{
    public void Configure(EntityTypeBuilder<Incident> builder)
    {

            builder.Property(n => n.Name)
                .IsRequired();
            builder.Property(d => d.Description)
                .IsRequired();
            builder.HasMany(a => a.Accounts)
            .WithOne(i => i.Incident)
            .HasForeignKey(i => i.IncidentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
}