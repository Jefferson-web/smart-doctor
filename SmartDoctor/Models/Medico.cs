using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public partial class Medico
    {
        [Key]
        public int medicoId { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int especialidadId { get; set; }
        public int residenciaId { get; set; }
        public string CMP { get; set; }
        public string descripcion { get; set; }
        public string RNE { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
        public int edad { get; set; }
        public Especialidad Especialidad { get; set; }
        public Residencia Residencia { get; set; }
        public IEnumerable<Experiencia> Experiencias { get; set; }
        public IEnumerable<Estudio> Estudios { get; set; }
        public IEnumerable<Calificacion> Calificaciones { get; set; }
    }
}
