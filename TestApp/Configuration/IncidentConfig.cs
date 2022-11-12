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
        builder.HasMany(f => f.Accounts)
            .WithOne(f => f.Incident)
            .HasForeignKey(f => f.IncidentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
}