using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class PackagesController : Controller
    {
        private ApplicationDbContext _context;

        public PackagesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var packages = _context.Packages.ToList();
            if (User.IsInRole("CanManagePackages"))
                return View("List", packages);

            return View("ReadOnlyList", packages);
        }

        [Authorize(Roles = "CanManagePackages")]
        public ViewResult New()
        {
            var package = new Package();
            return View("PackageForm", package);
        }
        
        [Authorize]
        public ActionResult Edit(int id)
        {
            var package = _context.Packages.SingleOrDefault(p => p.Id == id);

            if (package == null)
                return HttpNotFound();

            return View("PackageForm", package);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Package package)
        {
            if (!ModelState.IsValid)
                return View("PackageForm", package);

            if (package.Id == 0)
                _context.Packages.Add(package);
            else
            {
                var packageInDb = _context.Packages.Single(p => p.Id == package.Id);
                packageInDb.Destination = package.Destination;
                packageInDb.Price = package.Price;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Packages");
        }

        public ActionResult Delete(int id)
        {
            var package = _context.Packages.SingleOrDefault(p => p.Id == id);

            if (package == null)
                return HttpNotFound();

            _context.Packages.Remove(package);
            _context.SaveChanges();

            return RedirectToAction("Index", "Packages");
        }
    }
}