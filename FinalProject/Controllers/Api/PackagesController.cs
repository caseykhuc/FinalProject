using AutoMapper;
using FinalProject.Dto;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers.Api
{
    public class PackagesController : ApiController
    {
        private ApplicationDbContext _context;

        public PackagesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/packages
        public IHttpActionResult GetPackages()
        {
            var packageDtos = _context.Packages.ToList().Select(Mapper.Map<Package, PackageDto>);

            return Ok(packageDtos);
        }

        // GET /api/packages/1
        public IHttpActionResult GetPackage(int id)
        {
            var package = _context.Packages.SingleOrDefault(p => p.Id == id);

            if (package == null)
                return NotFound();

            return Ok(Mapper.Map<Package, PackageDto>(package));
        }

        // POST /api/packages
        [HttpPost]
        public IHttpActionResult CreatePackage(PackageDto packageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var package = Mapper.Map<PackageDto, Package>(packageDto);
            _context.Packages.Add(package);
            _context.SaveChanges();

            packageDto.Id = package.Id;
            return Created(new Uri(Request.RequestUri + "/" + package.Id), packageDto);
        }

        // PUT /api/packages/1
        [HttpPut]
        public IHttpActionResult UpdatePackage(int id, PackageDto packageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var packageInDb = _context.Packages.SingleOrDefault(p => p.Id == id);

            if (packageInDb == null)
                return NotFound();

            Mapper.Map(packageDto, packageInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/packages/1
        [HttpDelete]
        public IHttpActionResult DeletePackage(int id)
        {
            var packageInDb = _context.Packages.SingleOrDefault(p => p.Id == id);

            if (packageInDb == null)
                return NotFound();

            _context.Packages.Remove(packageInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
