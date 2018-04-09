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
    }
}
