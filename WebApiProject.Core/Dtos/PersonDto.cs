using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiProject.Core.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "{0} {1} karakterden uzun olmamalı.")] // {1} display name(max-length)
        [MinLength(3, ErrorMessage = "{0} {1} karakterden kısa olmamalı")] // {1} display name(min-length)
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
