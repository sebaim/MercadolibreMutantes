using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenMercadolibreMutantes.Models
{
    public abstract class Audit
    {
        public DateTime CreateDttm { get; set; }
        public DateTime UpdateDttm { get; set; }
    }
}
