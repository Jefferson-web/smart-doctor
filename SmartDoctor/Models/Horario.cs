using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public class Horario
    {
        [Key]
        public int horarioId { get; set; }
        [Required]
        public int consultaId { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime fecha_atencion { get; set; }
        [Required]
        public DateTime inicio_atencion { get; set; }
        [Required]
        public DateTime fin_atencion { get; set; }
        public bool disponible { get; set; }
        public DateTime fecha_registro { get; set; }
    }
}
