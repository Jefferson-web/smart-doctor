using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public class Cita
    {
        [Key]
        public int citaId { get; set; }
        [Required]
        public int consultaId { get; set; }
        [Required]
        public int pacienteId { get; set; }
        [Required]
        public DateTime inicio_cita { get; set; }
        [Required]
        public DateTime fin_cita { get; set; }
        [Required]
        public DateTime fecha_registro { get; set; }
        [Required]
        public string motivo { get; set; }
        public double costo { get; set; }
        public IEnumerable<Archivo> Archivos { get; set; }
    }
}
