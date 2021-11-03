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
    public class ConocerMedicosController : ControllerBase
    {
        private readonly IMapper mapper;
        public ConocerMedicosController(IMapper mapper)
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

        [Route("[action]")]
        [HttpGet]
        public IEnumerable<Medico> ListarMedicos(string q, int especialidadId = 0) {
            MedicosSOA soa = new MedicosSOA();
            var medicos = soa.ListarMedicos();
            if (especialidadId != 0)
            {
                medicos = medicos.Where(medico => medico.especialidadId == especialidadId).ToList();
            }
            if (!String.IsNullOrEmpty(q))
            {
                medicos = medicos.Where(medico => medico.nombres.Contains(q)
                || medico.apellidos.Contains(q));
            }
            return medicos;
        }

        [Route("[action]/{medicoId:int}")]
        [HttpGet]
        public ActionResult<Medico> VerPerfil(int medicoId) {
            if (String.IsNullOrEmpty(medicoId.ToString())) return BadRequest();
            MedicosSOA soa = new MedicosSOA();
            var medico = soa.VerPerfil(medicoId);
            if (medico is null)
            {
                return NotFound();    
            }
            return medico;
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult<Calificacion> Calificar([FromBody] Calificacion calificacion) {
            if (!ModelState.IsValid) return BadRequest();
            CalificacionSOA soa = new CalificacionSOA();
            var resultado = soa.Calificar(calificacion);
            return Ok(resultado);
        }

        [Route("[action]/{medicoId:int}")]
        [HttpGet]
        public ActionResult<IEnumerable<Calificacion>> ListarComentarios(int medicoId) {
            if (String.IsNullOrEmpty(medicoId.ToString())) return BadRequest();
            CalificacionSOA soa = new CalificacionSOA();
            var comentarios = soa.ListarComentarios(medicoId);
            return Ok(comentarios);
        }

    }
}
