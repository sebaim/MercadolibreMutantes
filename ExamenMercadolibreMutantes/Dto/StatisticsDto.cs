using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenMercadolibreMutantes.Dto
{
    public class StatisticsDto
    {
        [JsonProperty("count_mutant_dna")]
        public int MutantDnaCount { get; set; }

        [JsonProperty("count_human_dna")]
        public int HumanDnaCount { get; set; }

        [JsonProperty("ratio")]
        public decimal Ratio
        {
            get
            {
                return HumanDnaCount == 0 ? 0 : (decimal)MutantDnaCount / HumanDnaCount;
            }
        }
    }
}
