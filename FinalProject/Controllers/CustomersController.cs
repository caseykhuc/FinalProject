using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
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
            var customers = _context.Customers.ToList();
            var email = Session["Email"].ToString();
            var customer = _context.Customers.SingleOrDefault(m=> m.Email == email);
            if (User.IsInRole("CanManagePackages"))
                return View("Index", customers);
            return View("UserViewList", customer);
        }

        public ViewResult New()
        {
            var customer = new Customer();
            return View("CustomerForm", customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View("CustomerForm", customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
                return View("CustomerForm", customer);

            var customerInDb = _context.Customers.Single(c => c.Name == customer.Name);
            customerInDb.Name = customer.Name;
            customerInDb.Phone = customer.Phone;

            _context.SaveChanges();

            return View("UserViewList", customer);
        }

        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Bookings");
        }
    }
}