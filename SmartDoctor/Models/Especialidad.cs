using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public partial class Especialidad
    {
        [Key]
        public int especialidadId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}
