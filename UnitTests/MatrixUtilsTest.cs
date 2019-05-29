using ExamenMercadolibreMutantes.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    class MatrixUtilsTest
    {
        string[] MutantExample = new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };

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
        public void GetRowTest()
        {
            var row = MatrixUtils.GetRow(MutantExample, 1);
            Assert.AreEqual("CAGTGC", row);

            row = MatrixUtils.GetRow(MutantExample, 3);
            Assert.AreEqual("AGAAGG", row);
        }


        [Test]
        public void GetColumnTest()
        {
            var columm = MatrixUtils.GetColumn(MutantExample, 1);
            Assert.AreEqual("TATGCC", columm);

            columm = MatrixUtils.GetColumn(MutantExample, 5);
            Assert.AreEqual("ACTGAG", columm);
        }



        [Test]
        public void GetTopLeftDiagonal()
        {
            var leftTopDiagonal = MatrixUtils.GetLeftTopDiagonal(MutantExample, 1);
            Assert.AreEqual("CT", leftTopDiagonal);

            leftTopDiagonal = MatrixUtils.GetLeftTopDiagonal(MutantExample, 5);
            Assert.AreEqual("TCATGA", leftTopDiagonal);

        }


        [Test]
        public void GetTopRightDiagonal()
        {
            var leftTopDiagonal = MatrixUtils.GetTopRightDiagonal(MutantExample, 1);
            Assert.AreEqual("CG", leftTopDiagonal);

            leftTopDiagonal = MatrixUtils.GetTopRightDiagonal(MutantExample, 5);
            Assert.AreEqual("GTAAAA", leftTopDiagonal);

        }

        [Test]
        public void GetBottonLeftDiagonal()
        {
            var bottomLeftDiagonal = MatrixUtils.GetLeftBottomDiagonal(MutantExample, 1);
            Assert.AreEqual("TGCC", bottomLeftDiagonal);

            bottomLeftDiagonal = MatrixUtils.GetLeftBottomDiagonal(MutantExample, 3);
            Assert.AreEqual("CC", bottomLeftDiagonal);
        }

        [Test]
        public void GetBottonRightDiagonal()
        {
            var bottomRightDiagonal = MatrixUtils.GetRightBottomDiagonal(MutantExample, 1);
            Assert.AreEqual("TGCA", bottomRightDiagonal);

            bottomRightDiagonal = MatrixUtils.GetRightBottomDiagonal(MutantExample, 3);
            Assert.AreEqual("AT", bottomRightDiagonal);
        }

    }
}
