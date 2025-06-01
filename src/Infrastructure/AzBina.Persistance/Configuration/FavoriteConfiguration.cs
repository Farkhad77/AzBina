using AzBina.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzBina.Persistance.Configuration;

public class FavoriteConfiguration:IEntityTypeConfiguration<Favorite>
{
    public void Configure(EntityTypeBuilder<Favorite> builder)
    {
        builder.HasKey(f => f.Id);

        builder.HasOne(f => f.Ad)
            .WithMany(a => a.Favorites)
            .HasForeignKey(f => f.AdId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(f => f.AdId)
            .IsRequired();
    }

}
