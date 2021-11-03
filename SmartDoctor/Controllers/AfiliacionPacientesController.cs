using Microsoft.AspNetCore.Mvc;
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
        [HttpPut]
        public ActionResult<Paciente> Editar([FromBody] Paciente paciente) {
            PacienteSOA soa = new PacienteSOA();
            if (soa.Existe(paciente.pacienteId))
            {
                soa.Editar(paciente);
                return paciente;
            }
            else {
                return NotFound();
            }
        }
    }
}
