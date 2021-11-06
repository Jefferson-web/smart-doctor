using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.DTOs
{
    public class EditarMedicoDTO
    {
        [Required]
        public int medicoId { get; set; }
        [Required]
        public string nombres { get; set; }
        [Required]
        public string CMP { get; set; }
        [Required]
        public string celular { get; set; }
        [Required]
        public string correo { get; set; }
        public string descripcion { get; set; }
    }
}
