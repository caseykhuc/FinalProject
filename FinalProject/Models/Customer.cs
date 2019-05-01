using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Full Name")]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}