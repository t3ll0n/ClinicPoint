using ClinicPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicPoint.ViewModels
{
    public class AppointmentFormViewModel
    {
        public IEnumerable<Patient> Patients { get; set; }
        public IEnumerable<Physician> Physicians { get; set; }
        public Appointment Appointment { get; set; }

        public string Title
        {
            get
            {
                return Appointment.Id != 0 ? "Edit Appointment" : "New Appointment";
            }
        }

    }
 }