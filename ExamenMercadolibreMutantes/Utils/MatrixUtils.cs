using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenMercadolibreMutantes.Utils
{
    public static class MatrixUtils
    {
        public static bool IsSquareMatrix(string[] dna)
        {
            int columns = dna.Length;
            bool isSquare = true;
            int i = 0;

            while (isSquare && i < dna.Length - 1)
            {
                isSquare = columns == dna[i].Length;
                i++;
            }

            return isSquare;
        }

        public static bool ContainsInvalidCharacters(string[] dna, char[] validCharacters)
        {
            for (int i = 0; i < dna.Length; i++)
            {
                for (int j = 0; j < dna[i].Length; j++)
                {
                    if (!validCharacters.Contains(dna[i][j]))
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        public static string GetLeftBottomDiagonal(string[] dna, int columnNumber)
        {
            string bottomLeftDiagonañ = string.Empty;

            for (var j = 0; j < dna.Length - columnNumber - 1; j++)
            {
                bottomLeftDiagonañ += dna[columnNumber + j + 1][j];
            }

            return bottomLeftDiagonañ;
        }


        public static string GetTopRightDiagonal(string[] dna, int columnNumber)
        {
            string topRightDiagonal = string.Empty;

            for (var j = 0; j <= columnNumber; j++)
            {
                topRightDiagonal += dna[columnNumber - j][dna.Length - j - 1];
            }

            return topRightDiagonal;

        }

        public static string GetRow(string[] dna, int iterationNumber)
        {
            return dna[iterationNumber];
        }

        public static string GetLeftTopDiagonal(string[] dna, int rowNumber)
        {
            string leftTopDiagonal = string.Empty;

            for (var j = 0; j <= rowNumber; j++)
            {
                leftTopDiagonal += dna[rowNumber - j][j];
            }

            return leftTopDiagonal;

        }

        public static string GetRightBottomDiagonal(string[] dna, int rowNumber)
        {
            string rightBottomDiagonal = string.Empty;

            for (var j = 0; j < dna.Length - rowNumber - 1; j++)
            {
                rightBottomDiagonal += dna[j + rowNumber + 1][dna.Length - j - 1];
            }

            return rightBottomDiagonal;
        }

        public static string GetColumn(string[] dna, int columnNumber)
        {
            string column = string.Empty;

            for (int i = 0; i < dna.Length; i++)
            {
                column += dna[i][columnNumber];
            }

            return column;
        }
    }
}
