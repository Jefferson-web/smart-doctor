using Microsoft.EntityFrameworkCore;
using SmartDoctor.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public partial class PacienteSOA
    {

        public static Paciente AdicionarPaciente(Paciente paciente) {
            DataContext ctx = new DataContext();
            paciente.fecha_registro = DateTime.Now;
            ctx.Pacientes.Add(paciente);
            ctx.SaveChanges();
            return paciente;
        }

        public static IEnumerable<Paciente> ListarPacientes() {
            DataContext ctx = new DataContext();
            var pacientes = ctx.Pacientes   
                .ToList();
            return pacientes;
        }

        public static void Desafiliar(Paciente paciente) {
            DataContext ctx = new DataContext();
            ctx.Pacientes.Remove(paciente);
            ctx.SaveChanges();
        }

        public static Paciente Editar(Paciente paciente) {
            DataContext ctx = new DataContext();
            Paciente p = GetPacienteById(paciente.pacienteId);
            p.nombres = paciente.nombres;
            p.apellidos = paciente.apellidos;
            p.DNI = paciente.DNI;
            p.fecha_nacimiento = paciente.fecha_nacimiento;
            p.edad = paciente.edad;
            p.sexo = paciente.sexo;
            p.distrito_colonia = paciente.distrito_colonia;
            ctx.Pacientes.Update(p);
            ctx.SaveChanges();
            return p;
        }

        public static Paciente GetPacienteById(int pacienteId) {
            DataContext ctx = new DataContext();
            return ctx.Pacientes.Find(pacienteId);
        }

    }
}
