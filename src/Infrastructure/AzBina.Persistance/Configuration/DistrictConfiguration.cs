using AzBina.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzBina.Persistance.Configuration;

public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
      .IsRequired();

        builder.HasIndex(d => d.Name)
          .IsUnique();
    }
}
