using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartDoctor.DataAccess;
using SmartDoctor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramarConsultaController : ControllerBase
    {

        [HttpPost("RegistrarHorario")]
        public ActionResult<Horario> RegistrarHorario(int consultaId, DateTime fecha_atencion, DateTime inicio_atencion)
        {
            DataContext ctx = new DataContext();
            var consulta = ctx.Consultas.Find(consultaId);
            if (consulta == null)
                return NotFound();
            Horario horario = new Horario();
            horario.consultaId = consultaId;
            horario.fecha_atencion = fecha_atencion;
            horario.inicio_atencion = inicio_atencion;
            horario.fin_atencion = inicio_atencion.AddMinutes(consulta.duracion);
            horario.disponible = true;
            horario.fecha_registro = DateTime.Now;
            ctx.Horarios.Add(horario);
            ctx.SaveChanges();
            return Ok(horario);
        }

        [HttpGet("ListarHorarioDisponible")]
        public ActionResult<IEnumerable<Horario>> ListarHorarioDisponible(int consultaId, DateTime fecha) {
            DataContext ctx = new DataContext();
            var consulta = ctx.Consultas.Find(consultaId);
            if (consulta == null)
                return NotFound();
            var horariosDisponibles =  ctx.Horarios.Where(h => 
                h.consultaId == consultaId && 
                h.fecha_atencion == fecha &&
                h.disponible != false)
                .OrderBy(h => h.inicio_atencion)
                .ToList();
            return Ok(horariosDisponibles);
        }

        [HttpPost("ProgramarCita")]
        public ActionResult<Cita> ProgramarCita(int consultaId, int pacienteId, DateTime inicio_cita, string motivo) {
            
            DataContext ctx = new DataContext();
            var consulta = ctx.Consultas.Find(consultaId);
            if (consulta == null)
                return NotFound();

            var horario = ctx.Horarios.Where(h =>
                h.consultaId == consultaId &&
                h.fecha_atencion == inicio_cita.Date &&
                h.inicio_atencion == inicio_cita)
            .FirstOrDefault();
            if (horario == null)
                return NotFound();

            Cita cita = new Cita();
            cita.consultaId = consultaId;
            cita.pacienteId = pacienteId;
            cita.inicio_cita = inicio_cita;
            cita.fin_cita = inicio_cita.AddMinutes(consulta.duracion);
            cita.motivo = motivo;
            cita.fecha_registro = DateTime.Now;
            ctx.Citas.Add(cita);
            ctx.SaveChanges();

            horario.disponible = false;
            ctx.Horarios.Update(horario);
            ctx.SaveChanges();

            return cita;
        }

        [HttpPost("SubirArchivos")]
        public ActionResult<Cita> SubirArchivos(int citaId) {
            var files = Request.Form.Files;
            DataContext ctx = new DataContext();
            var cita = ctx.Citas.Find(citaId);
            if (cita == null)
                return NotFound();
            foreach (var file in files)
            {
                using var memory = new MemoryStream();
                file.CopyTo(memory);
                Archivo archivo = new Archivo();
                archivo.citaId = citaId;
                archivo.nombre = Path.GetFileNameWithoutExtension(file.FileName);
                archivo.extension = Path.GetExtension(file.FileName);
                archivo.tamano = file.Length;
                archivo.content_type = file.ContentType;
                archivo.data = memory.ToArray();
                ctx.Archivos.Add(archivo);
                ctx.SaveChanges();
            }
            return Ok("Archivo subidos correctamente.");
        }

    }
}
