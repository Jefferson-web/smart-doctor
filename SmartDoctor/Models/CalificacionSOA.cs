using Microsoft.EntityFrameworkCore;
using SmartDoctor.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public partial class CalificacionSOA
    {
        public Calificacion Calificar(Calificacion calificacion) {
            DataContext ctx = new DataContext();
            ctx.Calificaciones.Add(calificacion);
            ctx.SaveChanges();
            return calificacion;
        }

        public IEnumerable<Calificacion> ListarComentarios(int medicoId) {
            DataContext ctx = new DataContext();
            IEnumerable<Calificacion> calificaciones = ctx.Calificaciones
                    .Include(c => c.Medico)
                    .Include(p => p.Paciente)
                    .Where(c => c.medicoId == medicoId).ToList();
            return calificaciones;
        }

    }
}
