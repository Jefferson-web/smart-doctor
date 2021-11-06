using Microsoft.EntityFrameworkCore;
using SmartDoctor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.DataAccess
{
    public class DataContext: DbContext
    {
        public DataContext(){}
        public DataContext(DbContextOptions options): base(options){}
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Experiencia> Experiencias { get; set; }
        public DbSet<Estudio> Estudios { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Parentesco> Parentescos { get; set; }
        public DbSet<Residencia> Residencias { get; set; }
        public DbSet<SistemaOperativo> SistemaOperativos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=smartdoctordb;User Id=sa;Password=12345");
            }
        }
    }
}
