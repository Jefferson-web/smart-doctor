using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public class Consulta
    {
        [Key]
        public int consultaId { get; set; }
        [Required]
        public int medicoId { get; set; }
        [Required]
        public double importe { get; set; }
        [Required]
        public int duracion { get; set; }
        public DateTime fecha_registro { get; set; }
        public Medico Medico { get; set; }
        public IEnumerable<Horario> Horarios { get; set; }
        public IEnumerable<Cita> Citas { get; set; }
    }
}