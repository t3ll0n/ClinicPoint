using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicPoint.Models;
namespace ClinicPoint.ViewModels
{
    public class PatientFormViewModel
    {
        public Patient Patient { get; set; }

        public string Title
        {
            get
            {
                return Patient.Id != 0 ? "Edit Patient" : "New Patient";
            }
        }

    }
}