﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.DTOs
{
    public class MedicoDTO
    {
        [Required]
        public string nombres { get; set; }
        [Required]
        public int residenciaId { get; set; }
        [Required]
        public int especialidadId { get; set; }
        [Required]
        public int sistemaOperativoId { get; set; }
        [Required]
        public string CMP { get; set; }
        [StringLength(9)]
        public string celular { get; set; }
        [Required]
        public string correo { get; set; }
    }
}
