using SmartDoctor.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public partial class PacienteSOA
    {
        public void Editar(Paciente paciente) {
            DataContext ctx = new DataContext();
            Paciente p = ctx.Pacientes.Find(paciente.pacienteId);
            p.nombres = paciente.nombres;
            p.apellidos = paciente.apellidos;
            p.DNI = paciente.DNI;
            p.edad = paciente.edad;
            p.sexo = paciente.sexo;
            ctx.Pacientes.Update(p);
            ctx.SaveChanges();
        }

        public bool Existe(int pacienteId) {
            DataContext ctx = new DataContext();
            return ctx.Pacientes.Any(p => p.pacienteId == pacienteId);
        }

    }
}
