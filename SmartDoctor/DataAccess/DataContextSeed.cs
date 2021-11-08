using SmartDoctor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.DataAccess
{
    public class DataContextSeed
    {

        public static async Task SeedAsync(DataContext context) {
            if (!context.Especialidades.Any())
            {
                context.Especialidades.AddRange(getEspecialidades());
                await context.SaveChangesAsync();
            }
            if (!context.Residencias.Any())
            {
                context.Residencias.AddRange(getResidencias());
                await context.SaveChangesAsync();
            }
            if (!context.SistemaOperativos.Any())
            {
                context.SistemaOperativos.AddRange(GetSistemaOperativos());
                await context.SaveChangesAsync();
            }
        }

        public static IEnumerable<SistemaOperativo> GetSistemaOperativos() {
            return new List<SistemaOperativo>()
            {
                new SistemaOperativo(){ nombre = "Android" },
                new SistemaOperativo() { nombre = "IOs" }
            };
        }

        public static IEnumerable<Residencia> getResidencias() {
            return new List<Residencia>() {
                new Residencia() { pais = "Perú" },
                new Residencia() { pais = "México" },
                new Residencia() { pais = "Colombia" }
            };
        }

        private static IEnumerable<Especialidad> getEspecialidades() {
            return new List<Especialidad>()
            {
                new Especialidad(){ nombre = "Medicina General" },
                new Especialidad(){ nombre = "Psicología" },
                new Especialidad(){ nombre = "Psiquiatría" },
                new Especialidad(){ nombre = "Pediatría" },
                new Especialidad(){ nombre = "Endocrinología" },
                new Especialidad(){ nombre = "Nutrición" },
                new Especialidad(){ nombre = "Reumatología" },
                new Especialidad(){ nombre = "Cardiología" },
                new Especialidad(){ nombre = "Cirugia General" },
                new Especialidad(){ nombre = "Dermatología" },
                new Especialidad(){ nombre = "Endocrinologia Pediátrica" },
                new Especialidad(){ nombre = "Fisioterapia" },
                new Especialidad(){ nombre = "Gestroenterología" },
                new Especialidad(){ nombre = "Geriatría" },
                new Especialidad(){ nombre = "Ginecología" },
                new Especialidad(){ nombre = "Hermatología" },
                new Especialidad(){ nombre = "Medicina Familiar y Comunitaria" },
                new Especialidad(){ nombre = "Medicina Física y Rehabilitación" },
                new Especialidad(){ nombre = "Medicina Interna" },
                new Especialidad(){ nombre = "Neumología" },
                new Especialidad(){ nombre = "Neumologia Pediátrica" },
                new Especialidad(){ nombre = "Neurología" },
                new Especialidad(){ nombre = "Odontología" },
                new Especialidad(){ nombre = "Oftalmología" },
                new Especialidad(){ nombre = "Oncología" },
                new Especialidad(){ nombre = "Otorrinoraingología" },
                new Especialidad(){ nombre = "Urología" },
                new Especialidad(){ nombre = "Urologia Pediátrica" },
                new Especialidad(){ nombre = "Gestroenterologia Pediátrica" },
                new Especialidad(){ nombre = "Neurocirugía" }
            };
        }

    }
}
