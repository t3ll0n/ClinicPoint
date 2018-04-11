using ClinicPoint.Models;
using ClinicPoint.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;

namespace ClinicPoint.Controllers.Api
{
    public class PatientsController : ApiController
    {
        private ApplicationDbContext _context;

        public PatientsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/patients
        public IHttpActionResult GetPatients(string query = null)
        {
            var patientsQuery = from p in _context.Patients select p;

            if (!String.IsNullOrWhiteSpace(query))
                patientsQuery = patientsQuery.Where(p => p.FirstName.Contains(query) || p.LastName.Contains(query));

            var patientDto = patientsQuery
                .ToList()
                .Select(Mapper.Map<Patient, PatientDto>);

            return Ok(patientDto);
        }

        // GET api/patients/1
        public IHttpActionResult GetPatient(int id)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (patient == null)
                return NotFound();

            return Ok(Mapper.Map<Patient, PatientDto>(patient));
        }

        // POST api/patients
        [HttpPost]
        public IHttpActionResult CreatePatient(PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var patient = Mapper.Map<PatientDto, Patient>(patientDto);
            _context.Patients.Add(patient);
            _context.SaveChanges();

            patientDto.Id = patient.Id;

            return Created(new Uri(Request.RequestUri + "/" + patient.Id), patientDto);
        }

        // PUT api/patients/1
        [HttpPut]
        public IHttpActionResult UpdatePatient(int id, PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var patientInDb = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (patientInDb == null)
                return NotFound();

            Mapper.Map(patientDto, patientInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/patients/1
        [HttpDelete]
        public IHttpActionResult DeletePatient(int id)
        {
            var patientInDb = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (patientInDb == null)
                return NotFound();

            _context.Patients.Remove(patientInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
