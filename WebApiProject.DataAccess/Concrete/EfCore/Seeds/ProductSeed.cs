using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiProject.Core.Entities;

namespace WebApiProject.DataAccess.Concrete.EfCore.Seeds
{
    class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _Ids;

        public ProductSeed(int[] ids)
        {
            _Ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id=1,
                Name="Monster Abra A7",
                Price= 6399,
                Stock=50,
                CategoryId = _Ids[0]
            },
            new Product
            {
                Id = 2,
                Name = "Macbook Pro 13 inch ",
                Price =7399,
                Stock = 20,
                CategoryId = _Ids[0]
            },
            new Product
            {
                Id = 3,
                Name = "Macbook Pro 16 inch",
                Price = 8899,
                Stock = 40,
                CategoryId = _Ids[0]
            },
            new Product
            {
                Id = 4,
                Name = "Apple iPhone 12",
                Price = 9489,
                Stock = 200,
                CategoryId = _Ids[1]
            }
            );
        }
    }
}
