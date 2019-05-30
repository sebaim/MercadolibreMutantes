using ExamenMercadolibreMutantes.Dto;
using ExamenMercadolibreMutantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenMercadolibreMutantes.Services
{
    public interface IAnalysisLogService
    {
        StatisticsDto GetStatistics();

        void SaveOrUpdateLog(string [] dna, bool isMutant, DateTime actualDateTime);

      
    }

}
