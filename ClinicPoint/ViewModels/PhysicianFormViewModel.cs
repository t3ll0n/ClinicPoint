using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicPoint.Models;
namespace ClinicPoint.ViewModels
{
    public class PhysicianFormViewModel
    {
        public IEnumerable<SpecialtyType> SpecialtyTypes { get; set; }
        public Physician Physician  { get; set; }

        public string Title
        {
            get
            {
                return Physician.Id != 0 ? "Edit Physician" : "New Physician";
            }
        }
    }
}