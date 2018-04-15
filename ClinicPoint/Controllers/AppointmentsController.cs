using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicPoint.Models;
using ClinicPoint.ViewModels;
namespace ClinicPoint.Controllers
{
    public class AppointmentsController : Controller
    {
        private ApplicationDbContext _context;

        public AppointmentsController()
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
            var viewModel = new AppointmentFormViewModel
            {
                Appointment = new Appointment(),
                Patients = _context.Patients.ToList(),
                Physicians = _context.Physicians.ToList()
            };

            return View("AppointmentForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var appointment = _context.Appointments.SingleOrDefault(a => a.Id == id);

            if (appointment == null)
                return HttpNotFound();

            var viewModel = new AppointmentFormViewModel()
            {
                Appointment = appointment,
                Patients = _context.Patients.ToList(),
                Physicians = _context.Physicians.ToList()
            };

            return View("AppointmentForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AppointmentFormViewModel()
                {
                    Appointment = appointment,
                    Patients = _context.Patients.ToList(),
                    Physicians = _context.Physicians.ToList()
                };

                return View("AppointmentForm", viewModel);
            }
            if (appointment.Id == 0)
                _context.Appointments.Add(appointment);
            else
            {
                var appointmentInDb = _context.Appointments.Single(a => a.Id == appointment.Id);
                appointmentInDb.Patient = appointment.Patient;
                appointmentInDb.Physician = appointment.Physician;
                appointmentInDb.Date = appointment.Date;
                appointmentInDb.Time = appointment.Time;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Appointments");
        }
    }
}