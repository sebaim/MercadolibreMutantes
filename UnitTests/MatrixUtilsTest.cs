using ExamenMercadolibreMutantes.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    class MatrixUtilsTest
    {
        string[] mutantExample = new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
        char[] validCharacters = new char[] { 'A', 'T', 'C', 'G' };

        ///  "A T G C G A"
        ///  "C A G T G C"
        ///  "T T A T G T"
        ///  "A G A A G G"
        ///  "C C C C T A"
        ///  "T C A C T G"    

        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void MatrixContainsValidCharacters()
        {
            var containsInvalidCharacters = MatrixUtils.ContainsInvalidCharacters(mutantExample, validCharacters);

            Assert.IsFalse(containsInvalidCharacters);
        }


        [Test]
        public void MatrixContainsInvalidCharacters()
        {
            string[] mutantExample = new string[] { "ATGCGA", "CAGTGC", "TTATZT", "AGAAGG", "CCCCTA", "TCACTZ" };

            var containsInvalidCharacters = MatrixUtils.ContainsInvalidCharacters(mutantExample, validCharacters);

            Assert.IsTrue(containsInvalidCharacters);
        }

        [Test]
        public void IsSquareMatrix()
        {
            var isSquare = MatrixUtils.IsSquareMatrix(mutantExample);

            Assert.IsTrue(isSquare);
        }

        [Test]
        public void IsNotSquareMatrix()
        {
            string[] noSquareExample = new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA" };
            var isSquare = MatrixUtils.IsSquareMatrix(noSquareExample);

            Assert.IsFalse(isSquare);
        }

        [Test]
        public void IsNotSquareMatrixBecauseOneRowWithLessColumns()
        {
            string[] noSquareExample = new string[] { "ATGCGA", "CAGTGC", "TTATG", "AGAAGG", "CCCCTA", "TCACTG" };
            var isSquare = MatrixUtils.IsSquareMatrix(noSquareExample);

            Assert.IsFalse(isSquare);
        }


        [Test]
        public void GetRowTest()
        {
            var row = MatrixUtils.GetRow(mutantExample, 1);
            Assert.AreEqual("CAGTGC", row);

            row = MatrixUtils.GetRow(mutantExample, 3);
            Assert.AreEqual("AGAAGG", row);
        }


        [Test]
        public void GetColumnTest()
        {
            var columm = MatrixUtils.GetColumn(mutantExample, 1);
            Assert.AreEqual("TATGCC", columm);

            columm = MatrixUtils.GetColumn(mutantExample, 5);
            Assert.AreEqual("ACTGAG", columm);
        }



        [Test]
        public void GetTopLeftDiagonal()
        {
            var leftTopDiagonal = MatrixUtils.GetLeftTopDiagonal(mutantExample, 1);
            Assert.AreEqual("CT", leftTopDiagonal);

            leftTopDiagonal = MatrixUtils.GetLeftTopDiagonal(mutantExample, 5);
            Assert.AreEqual("TCATGA", leftTopDiagonal);

        }


        [Test]
        public void GetTopRightDiagonal()
        {
            var leftTopDiagonal = MatrixUtils.GetTopRightDiagonal(mutantExample, 1);
            Assert.AreEqual("CG", leftTopDiagonal);

            leftTopDiagonal = MatrixUtils.GetTopRightDiagonal(mutantExample, 5);
            Assert.AreEqual("GTAAAA", leftTopDiagonal);

        }

        [Test]
        public void GetBottonLeftDiagonal()
        {
            var bottomLeftDiagonal = MatrixUtils.GetLeftBottomDiagonal(mutantExample, 1);
            Assert.AreEqual("TGCC", bottomLeftDiagonal);

            bottomLeftDiagonal = MatrixUtils.GetLeftBottomDiagonal(mutantExample, 3);
            Assert.AreEqual("CC", bottomLeftDiagonal);
        }

        [Test]
        public void GetBottonRightDiagonal()
        {
            var bottomRightDiagonal = MatrixUtils.GetRightBottomDiagonal(mutantExample, 1);
            Assert.AreEqual("TGCA", bottomRightDiagonal);

            bottomRightDiagonal = MatrixUtils.GetRightBottomDiagonal(mutantExample, 3);
            Assert.AreEqual("AT", bottomRightDiagonal);
        }

    }
}
