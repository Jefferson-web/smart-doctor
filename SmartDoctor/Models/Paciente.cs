using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public partial class Paciente: Persona
    {
        [Key]
        public int pacienteId { get; set; }
        public int parentescoId { get; set; }
        public string DNI { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int edad{ get; set; }
        public bool sexo { get; set; }
        public DateTime fecha_registro { get; set; }
        public string distrito_colonia { get; set; }
        public Parentesco Parentesco { get; set; }
    }
}
