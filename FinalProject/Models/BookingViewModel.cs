using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class BookingViewModel
    {
        public IEnumerable<Package> Packages { get; set; }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int PackageId { get; set; }

        public DateTime Date { get; set; }
    }
}