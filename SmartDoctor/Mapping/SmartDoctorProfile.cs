using AutoMapper;
using SmartDoctor.DTOs;
using SmartDoctor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Mapping
{
    public class SmartDoctorProfile: Profile
    {
        public SmartDoctorProfile()
        {
            CreateMap<MedicoDTO, Medico>().ReverseMap();
            CreateMap<PacienteDTO, Paciente>().ReverseMap();
            CreateMap<EditarPacienteDTO, Paciente>().ReverseMap();
            CreateMap<EditarMedicoDTO, Medico>().ReverseMap();
        }
    }
}
