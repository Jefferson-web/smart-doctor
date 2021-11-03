using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public class Calificacion
    {
        [Key]
        public int calificacionId { get; set; }
        [Required]
        public int medicoId { get; set; }
        [Required]
        public int pacienteId { get; set; }
        [Required]
        public double puntuacion { get; set; }
        public string comentario { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
    }
}
