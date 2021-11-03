using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public class Experiencia
    {
        [Key]
        public int experienciaId { get; set; }
        public int doctorId { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public Medico Medico { get; set; }
    }
}
