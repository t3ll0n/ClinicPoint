using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicPoint.Models;
using ClinicPoint.ViewModels;

namespace ClinicPoint.Controllers
{
    public class PhysiciansController : Controller
    {
        private ApplicationDbContext _context;

        public PhysiciansController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var viewModel = new PhysicianFormViewModel
            {
                Physician = new Physician(),
                SpecialtyTypes = _context.Specialties.ToList()
            };

            return View("PhysicianForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var physician = _context.Physicians.SingleOrDefault(p => p.Id == id);

            if (physician == null)
                return HttpNotFound();

            var viewModel = new PhysicianFormViewModel()
            {
                Physician = physician,
                SpecialtyTypes = _context.Specialties.ToList()
            };

            return View("PhysicianForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Physician physician)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PhysicianFormViewModel()
                {
                    Physician = physician,
                    SpecialtyTypes = _context.Specialties.ToList()
                };

                return View("PhysicianForm", viewModel);
            }
            if (physician.Id == 0)
                _context.Physicians.Add(physician);
            else
            {
                var physicianInDb = _context.Physicians.Single(p => p.Id == physician.Id);
                physicianInDb.FirstName = physician.FirstName;
                physicianInDb.LastName = physician.LastName;
                physicianInDb.Birthdate = physician.Birthdate;
                physicianInDb.SocialSecurityNumber = physician.SocialSecurityNumber;
                physicianInDb.Phone = physician.Phone;
                physicianInDb.Email = physician.Email;
                physicianInDb.SpecialtyType = physician.SpecialtyType;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Physicians");
        }
    }
}