using ClinicPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ClinicPoint.Dtos;
using System.Data.Entity;


namespace ClinicPoint.Controllers.Api
{
    public class PhysiciansController : ApiController
    {
        private ApplicationDbContext _context;

        public PhysiciansController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/physician
        public IHttpActionResult GetPhysicians(string query = null)
        {
            var physiciansQuery = _context.Physicians
                .Include(p => p.SpecialtyType);

            if (!String.IsNullOrWhiteSpace(query))
                physiciansQuery = physiciansQuery.Where(p => p.FirstName.Contains(query) || p.LastName.Contains(query));

            var physicianDto = physiciansQuery
                .ToList()
                .Select(Mapper.Map<Physician, PhysicianDto>);

            return Ok(physicianDto);
        }

        // GET api/physicians/1
        public IHttpActionResult GetPhysician(int id)
        {
            var physician = _context.Physicians.SingleOrDefault(p => p.Id == id);

            if (physician == null)
                return NotFound();

            return Ok(Mapper.Map<Physician, PhysicianDto>(physician));
        }

        // POST api/physician
        [HttpPost]
        public IHttpActionResult CreatePhysician(PhysicianDto physicianDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var physician = Mapper.Map<PhysicianDto, Physician>(physicianDto);
            _context.Physicians.Add(physician);
            _context.SaveChanges();

            physicianDto.Id = physician.Id;

            return Created(new Uri(Request.RequestUri + "/" + physician.Id), physicianDto);
        }

        // PUT api/physician/1
        [HttpPut]
        public IHttpActionResult UpdatePhysician(int id, PhysicianDto physicianDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var physicianInDb = _context.Physicians.SingleOrDefault(p => p.Id == id);

            if (physicianInDb == null)
                return NotFound();

            Mapper.Map(physicianDto, physicianInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/physician/1
        [HttpDelete]
        public IHttpActionResult DeletePhysician(int id)
        {
            var physicianInDb = _context.Physicians.SingleOrDefault(p => p.Id == id);

            if (physicianInDb == null)
                return NotFound();

            _context.Physicians.Remove(physicianInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}

