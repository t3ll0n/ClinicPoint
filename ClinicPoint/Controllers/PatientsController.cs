using ClinicPoint.Models;
using ClinicPoint.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicPoint.Controllers
{
    public class PatientsController : Controller
    {
        private ApplicationDbContext _context;

        public PatientsController()
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
            var viewModel = new PatientFormViewModel
            {
                Patient = new Patient(),
            };

            return View("PatientForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (patient == null)
                return HttpNotFound();

            var viewModel = new PatientFormViewModel
            {
                Patient = patient,
            };

            return View("PatientForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PatientFormViewModel
                {
                    Patient = patient,
                };

                return View("PatientForm", viewModel);
            }
            if (patient.Id == 0)
                _context.Patients.Add(patient);
            else
            {
                var patientInDb = _context.Patients.Single(p => p.Id == patient.Id);
                patientInDb.FirstName = patient.FirstName;
                patientInDb.LastName = patient.LastName;
                patientInDb.Birthdate = patient.Birthdate;
                patientInDb.SocialSecurityNumber = patient.SocialSecurityNumber;
                patientInDb.Phone = patient.Phone;
                patientInDb.Email = patient.Email;
            }
           
            _context.SaveChanges();

            return RedirectToAction("Index", "Patients");
        }
    }
}