using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenMercadolibreMutantes.Dal;
using ExamenMercadolibreMutantes.Dto;
using ExamenMercadolibreMutantes.Models;

namespace ExamenMercadolibreMutantes.Services
{
    public class AnalysisLogService : IAnalysisLogService
    {
        IAnalysisLogDal analysisLogDal;
        public AnalysisLogService(IAnalysisLogDal analysisLogDal)
        {
            this.analysisLogDal = analysisLogDal;
        }

        public StatisticsDto GetStatistics()
        {
            var humansDnaSum = analysisLogDal.GetHumanSum(); 
            var mutantsDnaSum = analysisLogDal.GetMutantSum();

            return new StatisticsDto { HumanDnaCount = humansDnaSum, MutantDnaCount = mutantsDnaSum };
        }     

        public void SaveOrUpdateLog(string[] dna, bool isMutant, DateTime actualDateTime)
        {
            var existingLog = analysisLogDal.GetExistingLog(dna);

            if (existingLog !=  null)
            {
                existingLog.Count++;
                existingLog.UpdateDttm = actualDateTime;

                analysisLogDal.UpdateLog(existingLog);
            }
            else
            {
                analysisLogDal.CreateNewLog(dna, isMutant, actualDateTime);
            }
        }
    }
}
