using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiProject.Core.Entities;
using WebApiProject.DataAccess.Concrete.EfCore.Configurations;
using WebApiProject.DataAccess.Concrete.EfCore.Seeds;

namespace WebApiProject.DataAccess.Concrete.EfCore.Context
{
    public class WebApiProjectContext : DbContext
    {
        public WebApiProjectContext(DbContextOptions<WebApiProjectContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
        }

    }
}
