using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Dto
{
    public class PackageDto
    {
        public int Id { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public double Price { get; set; }
    }
}