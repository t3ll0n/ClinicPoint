using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicPoint.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Display(Name = "SSN")]
        [Required]
        public int SocialSecurityNumber { get; set; }

        [Display(Name = "Date of Birth")]
        [Required]
        public DateTime Birthdate { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }
    }
}