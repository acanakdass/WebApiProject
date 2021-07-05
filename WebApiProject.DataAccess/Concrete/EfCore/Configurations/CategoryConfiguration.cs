using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiProject.Core.Entities;

namespace WebApiProject.DataAccess.Concrete.EfCore.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();    //.ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.ToTable("Categories");

           
        }
    }
}
