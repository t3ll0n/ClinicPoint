using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ClinicPoint.Models;
using ClinicPoint.Dtos;

namespace ClinicPoint.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Domain to Dto
            CreateMap<Patient, PatientDto>();

            //Dto to Domain
            CreateMap<PatientDto, Patient>();
        }
    }
}