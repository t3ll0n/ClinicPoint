using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicPoint.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public Patient Patient { get; set; }

        [Required]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }

        public Physician Physician { get; set; }

        [Required]
        [Display(Name = "Physician")]
        public int PhysicianId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Time { get; set; }
    }
}