using AzBina.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AzBina.Persistance.Configuration;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Image_Url)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(i => i.is_main)
            .IsRequired();

        builder.HasOne(i => i.Ad)
            .WithMany(a => a.Images)
            .HasForeignKey(i => i.AdId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(i => i.AdId)
            .IsRequired();
    }
}
