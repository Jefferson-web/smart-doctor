using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartDoctor.DataAccess;
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
        public AfiliacionMedicosController(){}

        [Route("[action]")]
        [HttpPost]
        public ActionResult<Medico> Registrar(int especialidadId, int residenciaId, int sistemaOperativoId, string nombres, string CMP, string celular, string correo) {
            DataContext ctx = new DataContext();
            Medico medico = new Medico();
            medico.especialidadId = especialidadId;
            medico.residenciaId = residenciaId;
            medico.sistemaOperativoId = sistemaOperativoId;
            medico.nombres = nombres;
            medico.CMP = CMP;
            medico.celular = celular;
            medico.correo = correo;
            ctx.Medicos.Add(medico);
            ctx.SaveChanges();
            return medico;
        }

        [HttpGet("ListarResidencias")]
        public IEnumerable<Residencia> ListarResidencias() {
            DataContext ctx = new DataContext();
            var residencias = ctx.Residencias.ToList();
            return residencias;
        }

        [Route("[action]")]
        [HttpPut]
        public ActionResult<Medico> ModificarDatos(int medicoId, int especialidadId, int residenciaId, string nombres, string CMP, string celular, string correo)
        {
            DataContext ctx = new DataContext();
            var medico = ctx.Medicos.Find(medicoId);
            if (medico == null)
                return NotFound();
            medico.especialidadId = especialidadId;
            medico.residenciaId = residenciaId;
            medico.nombres = nombres;
            medico.CMP = CMP;
            medico.celular = celular;
            medico.correo = correo;
            ctx.Medicos.Update(medico);
            ctx.SaveChanges();
            return medico;
        }

        [HttpPost("AgregarConsultorio")]
        public ActionResult<Consulta> AgregarConsultorio(int medicoId, double importe, int duracion) {
            DataContext ctx = new DataContext();
            var medico = ctx.Medicos.Find(medicoId);
            if (medico == null)
                return NotFound();
            Consulta consulta = new Consulta();
            consulta.medicoId = medicoId;
            consulta.importe = importe;
            consulta.duracion = duracion;
            consulta.fecha_registro = DateTime.Now;
            ctx.Consultas.Add(consulta);
            ctx.SaveChanges();
            return consulta;
        }

    }
}
