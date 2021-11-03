using AutoMapper;
using SmartDoctor.DTOs;
using SmartDoctor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Mapping
{
    public class MedicoProfile: Profile
    {
        public MedicoProfile()
        {
            CreateMap<MedicoDTO, Medico>().ReverseMap();
        }
    }
}
