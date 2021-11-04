using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.DTOs
{
    public class EditarPacienteDTO
    {
        [Required]
        public int pacienteId { get; set; }
        [Required]
        public string nombres { get; set; }
        [Required]
        public string apellidos { get; set; }
        [Required]
        public string DNI { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime fecha_nacimiento { get; set; }
        [Required]
        public int edad { get; set; }
        [Required]
        public bool sexo { get; set; }
        [Required]
        public string distrito_colonia { get; set; }
    }
}
