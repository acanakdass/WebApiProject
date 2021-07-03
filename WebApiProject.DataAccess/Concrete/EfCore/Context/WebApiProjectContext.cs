using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiProject.Core.Entities;

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
            
        }

    }
}
