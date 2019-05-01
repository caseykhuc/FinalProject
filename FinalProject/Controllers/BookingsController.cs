using FinalProject.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class BookingsController : Controller
    {
        private ApplicationDbContext _context;

        public BookingsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize]
        public ActionResult Index()
        {
            var email = Session["Email"].ToString();
            //if (User.IsInRole("CanManagePackages"))
            //    return View("Index", customers);
            //return View("UserViewList", customer);
            var bookings = _context.Bookings.Include(m => m.Customer).Include(n => n.Package).ToList();
            var bookingsUser = _context.Bookings
                .Include(m => m.Customer)
                .Include(n => n.Package).Where(m => m.Customer.Email == email).ToList();
            if (User.IsInRole("CanManagePackages"))
                return View("Index", bookings);

            return View("IndexUser", bookingsUser);
        }

        public ViewResult New()
        {
            var booking = new BookingViewModel() {
                Packages = _context.Packages.ToList()
            };
            return View("BookingForm", booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Booking booking)
        {
            if (!ModelState.IsValid)
                return View("BookingForm", booking);

            if (booking.Id == 0)
            {
                var email = Session["Email"].ToString();
                var customer = _context.Customers.SingleOrDefault(m => m.Email == email);
                booking.Customer = customer;
                _context.Bookings.Add(booking);
            }
            else
            {
                var bookingInDb = _context.Bookings.Include(n => n.Package).SingleOrDefault(p => p.Id == booking.Id);
                bookingInDb.PackageId = booking.PackageId;
                bookingInDb.Date = booking.Date;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Bookings");
        }

        public ActionResult Edit(int id)
        {
            var booking = new BookingViewModel()
            {
                Packages = _context.Packages.ToList()
            };

            if (booking == null)
                return HttpNotFound();

            return View("BookingForm", booking);
        }

        public ActionResult Delete(int id)
        {
            var booking = _context.Bookings.SingleOrDefault(p => p.Id == id);

            if (booking == null)
                return HttpNotFound();

            _context.Bookings.Remove(booking);
            _context.SaveChanges();

            return RedirectToAction("Index", "Bookings");
        }
    }
}