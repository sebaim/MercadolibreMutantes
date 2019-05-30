using ExamenMercadolibreMutantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenMercadolibreMutantes.Dal
{
    public interface IAnalysisLogDal
    {
        int GetHumanSum();

        int GetMutantSum();

        MutantAnalysisLog GetExistingLog(string[] dna);

        void CreateNewLog(string[] dna, bool isMutant);

        void UpdateLog(MutantAnalysisLog mutantAnalysisLog);
    }
}
