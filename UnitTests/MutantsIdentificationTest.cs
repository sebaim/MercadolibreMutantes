using ExamenMercadolibreMutantes.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    class MutantsIdentificationTest
    {
        MutantsIdentificationService _mutantsIdentificationService = new MutantsIdentificationService();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsMutantWithTwoHorizontalSequences1()
        {
            var isMutant = _mutantsIdentificationService.IsMutant(new string[] { "AAAABAAAA" });
            Assert.IsTrue(isMutant);

            Assert.Pass();
        }

        [Test]
        public void IsMutantWithTwoHorizontalSequences2()
        {
            var isMutant = _mutantsIdentificationService.IsMutant(new string[] { "AAAAAAA" });
            Assert.IsFalse(isMutant);

            Assert.Pass();

        }

        [Test]
        public void IsMutantWithTwoHorizontalSequences3()
        {
            var isMutant = _mutantsIdentificationService.IsMutant(new string[] { "AAAABAAAA" });
            Assert.IsTrue(isMutant);

            Assert.Pass();

        }

        [Test]
        public void IsMutantWithTwoHorizontalSequences4()
        {
            var isMutant = _mutantsIdentificationService.IsMutant(new string[] { "AAAAAAAAAAAA" });
            Assert.IsTrue(isMutant);

            Assert.Pass();

        }

        [Test]
        public void IsMutantWithTwoHorizontalSequences5()
        {
            var isMutant = _mutantsIdentificationService.IsMutant(new string[] { "AAAAAABAAAA" });
            Assert.IsTrue(isMutant);

            Assert.Pass();

        }

        [Test]
        public void IsMutantWithTwoHorizontalSequences6()
        {
            var isMutant = _mutantsIdentificationService.IsMutant(new string[] { "CCAAAAABBBBAAA" });
            Assert.IsTrue(isMutant);

            Assert.Pass();

        }


        [Test]
        public void IsMutantWithOneHorizontalSequences()
        {
            var isMutant = _mutantsIdentificationService.IsMutant(new string[] { "CATG", "CTAG", "CBAA", "CHAA" });
            Assert.IsFalse(isMutant);

            Assert.Pass();

        }

        [Test]
        public void IsMutantExample()
        {
            var isMutant = _mutantsIdentificationService.IsMutant(new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" });
            Assert.IsTrue(isMutant);

            Assert.Pass();

        }
    }
}
