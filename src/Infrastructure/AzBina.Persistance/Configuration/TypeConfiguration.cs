using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzBina.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

    namespace AzBina.Persistence.Configurations;

    public class TypeConfiguration : IEntityTypeConfiguration<Domain.Entities.Type>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Type> builder)
        {
            builder.ToTable("Types");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(t => t.Name)
                .IsUnique();

            
            builder.HasOne(t => t.ParentType)
                .WithMany(t => t.SubTypes)
                .HasForeignKey(t => t.ParentTypeId)
                .OnDelete(DeleteBehavior.Restrict); 

        }
    }

