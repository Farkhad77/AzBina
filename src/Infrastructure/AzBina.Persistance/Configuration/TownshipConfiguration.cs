using AzBina.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzBina.Persistance.Configuration;

public class TownshipConfiguration : IEntityTypeConfiguration<Township>
{
    public void Configure(EntityTypeBuilder<Township> builder)
    {
       builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
              .IsRequired();

            builder.HasIndex(t => t.Name)
              .IsUnique();

            builder.HasMany(t => t.Ads)
            .WithOne(t => t.Town)
            .HasForeignKey(a => a.TownId)
            .OnDelete(DeleteBehavior.Restrict);
        
    }
}
