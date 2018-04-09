using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicPoint.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int SocialSecurityNumber { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }
    }
}