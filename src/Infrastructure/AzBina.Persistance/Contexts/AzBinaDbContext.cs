using AzBina.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Persistance.Contexts
{
    public class AzBinaDbContext : DbContext
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
       

    }
    
}
