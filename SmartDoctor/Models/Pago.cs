using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public class Pago
    {
        [Key]
        public int pagoId { get; set; }
        [Required]
        public int pacienteId { get; set; }
        [Required]
        public double monto { get; set; }
        [Required]
        public DateTime fecha_pago { get; set; }
    }
}
