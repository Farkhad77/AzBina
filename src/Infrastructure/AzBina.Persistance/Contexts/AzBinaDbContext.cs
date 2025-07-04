﻿using AzBina.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AzBina.Persistance.Contexts;

public class AzBinaDbContext : IdentityDbContext<AppUser>
{
    public AzBinaDbContext(DbContextOptions<AzBinaDbContext>options) : base(options)
    {
    }
    public DbSet<Bio> Bios { get; set; }
    public DbSet<Ad> Ads{ get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Township> Townships{ get; set; }
    public DbSet<Favorite> Favorites{ get; set; }
    public DbSet<Image> Images{ get; set; }
    public DbSet<Domain.Entities.Type> Types{ get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AzBinaDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

