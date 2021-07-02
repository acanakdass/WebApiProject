using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiProject.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public string InnerBarcode { get; set; }
        public virtual Category Category { get; set; }
    }
}
