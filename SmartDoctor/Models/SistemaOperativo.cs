using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public class SistemaOperativo
    {
        [Key]
        public int sistemaOperativoId { get; set; }
        public string nombre { get; set; }
    }
}
