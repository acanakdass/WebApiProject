using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebApiProject.Core.Entities;

namespace WebApiProject.Core.Dtos
{
    public class CategoryWithProductsDto:CategoryDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
