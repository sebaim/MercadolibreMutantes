using ExamenMercadolibreMutantes.Models;
using ExamenMercadolibreMutantes.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenMercadolibreMutantes.Services
{
    public class MutantsIdentificationService
    {
        private const int MUTANT_CONSECUTIVE_CHARACTERS = 4;
        private const int MUTANT_SEQUENCES_NUMBER = 2;

        private IAnalysisLogService analysisLogService;

        public MutantsIdentificationService(IAnalysisLogService analysisLogService)
        {
            this.analysisLogService = analysisLogService;
        }

        public bool IsMutant(string[] dna, DateTime actualDate)
        {
            int sequencesCounter = 0;

            for (int iterationNumber = 0; iterationNumber < dna.Length; iterationNumber++)
            {
                var row = MatrixUtils.GetRow(dna, iterationNumber);
                sequencesCounter += FindSequences(row);
                if (MoreThanOneSequencesFound(sequencesCounter)) break;

                var column = MatrixUtils.GetColumn(dna, iterationNumber);
                sequencesCounter += FindSequences(column);
                if (MoreThanOneSequencesFound(sequencesCounter)) break;

                var bottomToLeftDiagonal = MatrixUtils.GetLeftBottomDiagonal(dna, iterationNumber);
                sequencesCounter += FindSequences(bottomToLeftDiagonal);
                if (MoreThanOneSequencesFound(sequencesCounter)) break;

                var topToRightDiagonal = MatrixUtils.GetTopRightDiagonal(dna, iterationNumber);
                sequencesCounter += FindSequences(topToRightDiagonal);
                if (MoreThanOneSequencesFound(sequencesCounter)) break;

                var leftTopDiagonal = MatrixUtils.GetLeftTopDiagonal(dna, iterationNumber);
                sequencesCounter += FindSequences(leftTopDiagonal);
                if (MoreThanOneSequencesFound(sequencesCounter)) break;

                var rightBottomDiagonal = MatrixUtils.GetRightBottomDiagonal(dna, iterationNumber);
                sequencesCounter += FindSequences(rightBottomDiagonal);
                if (MoreThanOneSequencesFound(sequencesCounter)) break;
            }

            var isMutant = MoreThanOneSequencesFound(sequencesCounter);

            analysisLogService.SaveOrUpdateLog(dna, isMutant, actualDate);

            return isMutant;
        }

        private bool MoreThanOneSequencesFound(int sequencesFound)
        {
            return sequencesFound >= MUTANT_SEQUENCES_NUMBER;
        }


        private int FindSequences(string row)
        {
            if (row.Length < MUTANT_CONSECUTIVE_CHARACTERS) return 0;
            
            int characterCounter = 1;
            int sequencesCounter = 0;

            int i = 0;

            while (i < row.Length - 1 && sequencesCounter < 2)
            {
                if (row[i] == row[i + 1])
                {
                    characterCounter++;

                    if (characterCounter == MUTANT_CONSECUTIVE_CHARACTERS)
                    {
                        sequencesCounter++;
                        characterCounter = 0;
                    }
                }
                else
                {
                    characterCounter = 1;
                }

                i++;
            };

            return sequencesCounter;
        }

    }
}
