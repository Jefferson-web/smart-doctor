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
    public class AfiliacionPacientesController : ControllerBase
    {
        private readonly IMapper mapper;

        public AfiliacionPacientesController(IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult<Paciente> AdicionarPaciente([FromBody] PacienteDTO pacienteDto) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Paciente paciente = mapper.Map<Paciente>(pacienteDto);
            Paciente p = PacienteSOA.AdicionarPaciente(paciente);
            return Ok(p);
        }

        [Route("[action]")]
        [HttpPut]
        public ActionResult<Paciente> EditarPaciente([FromBody] EditarPacienteDTO pacienteDto) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Paciente paciente = mapper.Map<Paciente>(pacienteDto);
            Paciente pacienteEditado = PacienteSOA.Editar(paciente);
            return Ok(pacienteEditado);
        }

        [HttpDelete("DesafiliarPaciente/{pacienteId:int}")]
        public IActionResult DesafiliarPaciente(int pacienteId) {
            Paciente paciente = PacienteSOA.GetPacienteById(pacienteId);
            if (paciente == null)
                return NotFound();
            PacienteSOA.Desafiliar(paciente);
            return Ok("El cliente fue desafiliado de la aplicación SmartDoctor");
        }

        [Route("[action]")]
        [HttpGet]
        public ActionResult<IEnumerable<Paciente>> ListarPacientes()
        {
            return Ok(PacienteSOA.ListarPacientes());
        }

    }
}
