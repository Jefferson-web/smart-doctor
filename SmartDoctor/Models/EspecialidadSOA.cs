using SmartDoctor.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public class EspecialidadSOA
    {
        public static IEnumerable<Especialidad> Listar() {
            DataContext ctx = new DataContext();
            var especialidades = ctx.Especialidades.ToList();
            return especialidades;
        }
    }
}
