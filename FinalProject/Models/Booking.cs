using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int PackageId { get; set; }

        public Customer Customer { get; set; }

        public Package Package { get; set; }

        [Display(Name = "Travel Date")]
        public DateTime Date { get; set; }
    }
}