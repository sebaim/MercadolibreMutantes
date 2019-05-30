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

        public override bool Equals(object obj)
        {
            return obj is MutantAnalysisLog log &&
                   Id == log.Id &&
                   Dna.SequenceEqual(log.Dna) &&
                   IsMutant == log.IsMutant &&
                   Count == log.Count;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Dna, IsMutant, Count);
        }
    }
}
