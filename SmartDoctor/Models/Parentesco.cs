using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDoctor.Models
{
    public class Parentesco
    {
        [Key]
        public int parentescoId { get; set; }
        public string parentesco { get; set; }
    }
}
