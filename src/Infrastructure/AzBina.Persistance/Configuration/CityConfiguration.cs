using AzBina.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Persistance.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired();

            builder.HasIndex(c => c.Name)
                .IsUnique();

            builder.HasMany(c => c.Districts)
            .WithOne(d => d.City)
            .HasForeignKey(d => d.CityId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Ads)
            .WithOne(a => a.City)
            .HasForeignKey(a => a.CityId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
