using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartDoctor.DataAccess;
using SmartDoctor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConocerMedicosController : ControllerBase
    {

        [HttpGet("ListarEspecialidades")]
        public IEnumerable<Especialidad> ListarEspecialidades() {
            DataContext ctx = new DataContext();
            IEnumerable<Especialidad> especialidades = ctx.Especialidades.ToList();
            return especialidades;
        }

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<Medico> ListarMedicos(string q, int especialidadId = 0)
        {
            DataContext ctx = new DataContext();
            IEnumerable<Medico> medicos = ctx.Medicos.ToList();
            if (especialidadId != 0)
            {
                medicos = medicos.Where(medico => medico.especialidadId == especialidadId).ToList();
            }
            if (!String.IsNullOrEmpty(q))
            {
                medicos = medicos.Where(medico => medico.nombres.Contains(q));
            }
            return medicos;
        }

        [Route("[action]/{medicoId:int}")]
        [HttpGet]
        public ActionResult<Medico> VerPerfil(int medicoId)
        {
            DataContext ctx = new DataContext();
            var medico =  ctx.Medicos
                .Include(m => m.Experiencias)
                .Include(m => m.Estudios)
                .Include(m => m.Residencia)
                .FirstOrDefault(medico => medico.medicoId == medicoId);
            if (medico == null)
            {
                return NotFound();
            }
            return medico;
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult<Calificacion> Calificar([FromBody] Calificacion calificacion)
        {
            if (!ModelState.IsValid) return BadRequest();
            CalificacionSOA soa = new CalificacionSOA();
            var resultado = soa.Calificar(calificacion);
            return Ok(resultado);
        }

        [Route("[action]/{medicoId:int}")]
        [HttpGet]
        public ActionResult<IEnumerable<Calificacion>> Reputacion(int medicoId)
        {
            if (String.IsNullOrEmpty(medicoId.ToString())) return BadRequest();
            CalificacionSOA soa = new CalificacionSOA();
            var comentarios = soa.ListarComentarios(medicoId);
            return Ok(comentarios);
        }


    }

}
