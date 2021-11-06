using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartDoctor.DTOs;
using SmartDoctor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AfiliacionMedicosController : ControllerBase
    {
        private readonly IMapper mapper;
        public AfiliacionMedicosController(IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult<Medico> Registrar([FromBody] MedicoDTO medicoDto) {
            if (!ModelState.IsValid) return BadRequest();
            Medico medico = mapper.Map<Medico>(medicoDto);
            MedicosSOA soa = new MedicosSOA();
            soa.Registrar(medico);
            return medico;
        }

        [HttpGet("ListarResidencias")]
        public IEnumerable<Residencia> ListarResidencias() {
            var residencias = ResidenciaSOA.Listar();
            return residencias;
        }

        [Route("[action]")]
        [HttpPut]
        public ActionResult<Medico> ModificarDatos([FromBody] EditarMedicoDTO medicoDto)
        {
            Medico medico = mapper.Map<Medico>(medicoDto);
            MedicosSOA soa = new MedicosSOA();
            soa.Editar(medico);
            return medico;
        }

    }
}
