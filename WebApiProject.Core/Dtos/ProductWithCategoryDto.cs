using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiProject.Core.Dtos
{
    public class ProductWithCategoryDto:ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
