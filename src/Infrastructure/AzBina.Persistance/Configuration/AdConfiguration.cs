using AzBina.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzBina.Persistance.Configuration;

public class AdConfiguration : IEntityTypeConfiguration<Ad>
{
    public void Configure(EntityTypeBuilder<Ad> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Room_Count)
            .IsRequired();
       
        builder.Property(a => a.for_sale)
            .IsRequired();
        
        builder.Property(a => a.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        
        builder.Property(a => a.Field)
            .HasColumnType("decimal(18,2)");
        
        builder.Property(a => a.House_Field)
            .HasColumnType("decimal(18,2)");
        
        builder.Property(a => a.Floor);
        
        builder.Property(a => a.Note)
            .HasMaxLength(1000);
        
        builder.Property(a => a.Deed)
            .IsRequired();
        
        builder.Property(a => a.Map)
            .HasMaxLength(500);
        
        builder.Property(a => a.Address)
            .HasMaxLength(1000);
        
        builder.Property(a => a.is_activated)
            .IsRequired();
        
        builder.Property(a => a.is_approved)
            .IsRequired();
        
        builder.Property(a => a.Building_Floor);
        
        builder.Property(a => a.is_repaired);
        
        builder.Property(a => a.Building_Type);

        builder.HasOne(a => a.Category)
               .WithMany(ct=>ct.Ads)
               .HasForeignKey(a => a.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.City)
               .WithMany(c => c.Ads)
               .HasForeignKey(a => a.CityId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Town)
               .WithMany(t => t.Ads)
               .HasForeignKey(a => a.TownId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.District)
               .WithMany(d => d.Ads)
               .HasForeignKey(a => a.DistrictId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Type)
               .WithMany(ty=>ty.Ads)
               .HasForeignKey(a => a.TypeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(a => a.Favorites)
               .WithOne(f => f.Ad)
               .HasForeignKey(f => f.AdId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(a => a.Images)
               .WithOne(i => i.Ad)
               .HasForeignKey(i => i.AdId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
