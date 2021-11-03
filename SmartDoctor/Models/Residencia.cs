using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public class Residencia
    {
        [Key]
        public int residenciaId { get; set; }
        [Required]
        public string nombre { get; set; }
    }
}
