using Microsoft.EntityFrameworkCore;
using SmartDoctor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Experiencia> Experiencias { get; set; }
        public DbSet<Estudio> Estudios { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Residencia> Residencias { get; set; }
        public DbSet<SistemaOperativo> SistemaOperativos { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Archivo> Archivos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=smartdoctordb;User Id=sa;Password=12345");
            }
        }
    }
}
