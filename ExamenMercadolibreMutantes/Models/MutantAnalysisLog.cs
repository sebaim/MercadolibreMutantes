using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenMercadolibreMutantes.Models
{
    public class MutantAnalysisLog : Audit
    {
        public long Id { get; set; }

        public string[] Dna { get; set; }

        public bool IsMutant { get; set; }

        public int Count { get; set; }
       
    }
}
