using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicPoint.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        public PatientDto Patient { get; set; }

        [Required]
        public int PatientId { get; set; }

        public PhysicianDto Physician { get; set; }

        [Required]
        public int PhysicianID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Time { get; set; }
    }
}