using SmartDoctor.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public class ResidenciaSOA
    {
        public static IEnumerable<Residencia> Listar() {
            DataContext ctx = new DataContext();
            var residencias = ctx.Residencias.ToList();
            return residencias;
        }
    }
}
