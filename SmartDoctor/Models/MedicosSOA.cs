using Microsoft.EntityFrameworkCore;
using SmartDoctor.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public partial class MedicosSOA
    {

        public Medico Registrar(Medico medico)
        {
            DataContext ctx = new DataContext();
            ctx.Medicos.Add(medico);
            ctx.SaveChanges();
            return medico;
        }

        public void Editar(Medico medico) {
            DataContext ctx = new DataContext();
            var medicoAEditar = ctx.Medicos.Find(medico.medicoId);
            if (medicoAEditar != null)
            {
                medicoAEditar.nombres = medico.nombres;
                medicoAEditar.CMP = medico.CMP;
                medicoAEditar.celular = medico.celular;
                medicoAEditar.correo = medico.correo;
                medicoAEditar.descripcion = medico.descripcion;
                ctx.Medicos.Update(medicoAEditar);
                ctx.SaveChanges();
            }
        }

        public Medico VerPerfil(int medicoId)
        {
            DataContext ctx = new DataContext();
            var medico = ctx.Medicos
                    .Include(m => m.Experiencias)
                    .Include(m => m.Estudios)
                    .Include(m => m.Residencia)
                    .FirstOrDefault(medico => medico.medicoId == medicoId);
            return medico;
        }

        public IEnumerable<Medico> ListarMedicos() {
            DataContext ctx = new DataContext();
            IEnumerable<Medico> medicos = ctx.Medicos
                .Include(m => m.Especialidad)
                .Include(m => m.Residencia)
                .ToList();
            return medicos;
        }

    }
}
