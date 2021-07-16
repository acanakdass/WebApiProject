using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiProject.Core.Dtos
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; set; }
        public int Status { get; set; }
    }
}
