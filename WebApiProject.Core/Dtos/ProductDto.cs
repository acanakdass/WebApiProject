using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiProject.Core.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        
    }
}
