using Newtonsoft.Json;
using System;

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
                var value = HumanDnaCount == 0 ? 0 : (decimal)MutantDnaCount / HumanDnaCount;
                return Math.Round(value, 2);
            }
        }
    }
}
