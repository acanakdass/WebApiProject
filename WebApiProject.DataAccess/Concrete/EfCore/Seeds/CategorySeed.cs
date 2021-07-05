using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiProject.Core.Entities;

namespace WebApiProject.DataAccess.Concrete.EfCore.Seeds
{
    class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _Ids;

        public CategorySeed(int[] ids)
        {
            _Ids = ids;
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = _Ids[0],
                Name = "Notebooks"
            },
            new Category
            {
                Id = _Ids[1],
                Name = "Phones"
            });
        }
    }
}
