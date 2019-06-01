using ExamenMercadolibreMutantes.Models;
using System;
using System.Linq;

namespace ExamenMercadolibreMutantes.Dal
{
    public class AnalysisLogDal : IAnalysisLogDal
    {
        private MutantsDbContext mutantsDbContext;

        public AnalysisLogDal(MutantsDbContext mutantsDbContext)
        {
            this.mutantsDbContext = mutantsDbContext;
        }

        public int GetHumanSum()
        {
            return mutantsDbContext.MutantAnalysisLogs.Where(l => !l.IsMutant).Sum(l => l.Count);
        }

        public int GetMutantSum()
        {
            return mutantsDbContext.MutantAnalysisLogs.Where(l => l.IsMutant).Sum(l => l.Count);
        }

        public MutantAnalysisLog GetExistingLog(string[] dna)
        {
            return mutantsDbContext.MutantAnalysisLogs.Where(log => log.Dna.SequenceEqual(dna)).FirstOrDefault();
        }

        public void UpdateLog(MutantAnalysisLog mutantAnalysisLog)
        {
            mutantsDbContext.MutantAnalysisLogs.Update(mutantAnalysisLog);
            mutantsDbContext.SaveChanges();
        }


        public void CreateNewLog(string[] dna, bool isMutant, DateTime actualDateTime)
        {
            MutantAnalysisLog newLog = new MutantAnalysisLog()
            {
                Count = 1,
                CreateDttm = actualDateTime,
                UpdateDttm = actualDateTime,
                Dna = dna,
                IsMutant = isMutant
            };

            mutantsDbContext.MutantAnalysisLogs.Add(newLog);

            mutantsDbContext.SaveChanges();
        }
    }
}
