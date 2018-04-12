using ClinicPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using ClinicPoint.Dtos;
using AutoMapper;

namespace ClinicPoint.Controllers.Api
{
    public class AppointmentsController : ApiController
    {
        private ApplicationDbContext _context;

        public AppointmentsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/appointments
        public IHttpActionResult GetAppointments()
        {
            var appointments = _context.Appointments.Include(a => a.Patient).Include(a => a.Physician)
                .ToList().Select(Mapper.Map<Appointment, AppointmentDto>);

            if (appointments == null)
                return NotFound();

            return Ok(appointments);
        }

        // GET api/appointments/1
        public IHttpActionResult GetAppointment(int id)
        {
            var appointment = _context.Appointments.SingleOrDefault(a => a.Id == id);

            if (appointment == null)
                return NotFound();

            return Ok(Mapper.Map<Appointment, AppointmentDto>(appointment));
        }

        // POST api/appointments
        [HttpPost]
        public IHttpActionResult CreateAppointment(AppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var appointment = Mapper.Map<AppointmentDto, Appointment>(appointmentDto);
            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + appointment.Id), appointmentDto);
        }

        // PUT /api/appointment/1
        [HttpPut]
        public IHttpActionResult UpdateAppointment(int id, AppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var appointmentInDb = _context.Appointments.SingleOrDefault(a => a.Id == id);

            if (appointmentInDb == null)
                return NotFound();

            Mapper.Map(appointmentDto, appointmentInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/appointment/1
        [HttpDelete]
        public IHttpActionResult DeleteAppointment(int id)
        {
            var appointmentInDb = _context.Appointments.SingleOrDefault(c => c.Id == id);

            if (appointmentInDb == null)
                return NotFound();

            _context.Appointments.Remove(appointmentInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
