using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public class Archivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string archivoId { get; set; }
        [Required]
        public int citaId { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public byte[] data { get; set; }
        [Required]
        public string content_type { get; set; }
        [Required]
        public long tamano { get; set; }
        [Required]
        public string extension { get; set; }
        [Required]
        public DateTime fecha_registro { get; set; }
    }
}
