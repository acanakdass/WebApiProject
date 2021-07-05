using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiProject.Core.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
