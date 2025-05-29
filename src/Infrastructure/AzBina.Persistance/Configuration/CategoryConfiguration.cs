using AzBina.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzBina.Persistance.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(ct => ct.Id);

        builder.Property(ct => ct.Name)
            .IsRequired();

        builder.HasIndex(ct => ct.Name)
            .IsUnique();
    }
}
