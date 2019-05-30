using ExamenMercadolibreMutantes.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    class MutantsIdentificationTest
    {
        Mock<IAnalysisLogService> mock;
        private MutantsIdentificationService mutantsIdentificationService;
        private DateTime actualDateTime;


        [SetUp]
        public void Setup()
        {
            mock = new Mock<IAnalysisLogService>();
            mutantsIdentificationService = new MutantsIdentificationService(mock.Object);
            actualDateTime = DateTime.Now;
        }

        /// A T G C A G
        /// C T A C C G
        /// T A C A T C
        /// A G A A T C
        /// C T C A T C
        /// A C G T C A
        [Test]
        public void IsNotMutantWithNoSequence()
        {
            string[] dna = { "ATGCAG", "CTACCG", "TACATC", "AGAATC", "CTCATC", "ACGTCA" };

            mock.Setup(m => m.SaveOrUpdateLog(dna, false, actualDateTime)).Verifiable();

            var isMutant = mutantsIdentificationService.IsMutant(dna, actualDateTime);
            Assert.IsFalse(isMutant);
            mock.Verify();
        }

        /// A T G C A G
        /// C T A A C G
        /// T A C A T C
        /// A G A A T C
        /// C T C A T C
        /// A C G T C A
        [Test]
        public void IsNotMutantWithOnlyOneSequence()
        {
            string[] dna = { "ATGCAG", "CTAACG", "TACATC", "AGAATC", "CTCATC", "ACGTCA" };

            mock.Setup(m => m.SaveOrUpdateLog(dna, false, actualDateTime)).Verifiable();

            var isMutant = mutantsIdentificationService.IsMutant(dna, actualDateTime);
            Assert.IsFalse(isMutant);
            mock.Verify();
        }

        /// A T G C A C
        /// C T A A T C
        /// T A C A T C
        /// A G A A T C
        /// C T C A T C
        /// A C G T C A
        [Test]
        public void IsMutantWith2VerticalSequences()
        {
            string[] dna = { "ATGCAC", "CTAATC", "TACATC", "AGAATC", "CTCATC", "ACGTCA" };

            mock.Setup(m => m.SaveOrUpdateLog(dna, true, actualDateTime)).Verifiable();

            var isMutant = mutantsIdentificationService.IsMutant(dna, actualDateTime);
            Assert.IsTrue(isMutant);
            mock.Verify();
        }

        /// A T G C G A
        /// A T A A A T
        /// T A C A G T
        /// A G A A T G
        /// C T C A T A
        /// A C G T C A
        [Test]
        public void IsMutantWith2DiagonalSequences()
        {
            string[] dna = { "ATGCGA", "ATAAAT", "TACAGT", "AGAATG", "CTCATA", "ACGTCA" };

            mock.Setup(m => m.SaveOrUpdateLog(dna, true, actualDateTime)).Verifiable();

            var isMutant = mutantsIdentificationService.IsMutant(dna, actualDateTime);
            Assert.IsTrue(isMutant);
            mock.Verify();
        }

        /// A T G C G A
        /// C T A A A A
        /// T T C T G T
        /// A T A A T G
        /// C C C A T A
        /// A C G T A A
        [Test]
        public void IsMutantWith1HorizontalAnd1VerticalSequences()
        {
            string[] dna = { "ATGCGA", "CTAAAA", "TTCTGT", "ATAATG", "CCCATA", "ACGTAA" };

            mock.Setup(m => m.SaveOrUpdateLog(dna, true, actualDateTime)).Verifiable();

            var isMutant = mutantsIdentificationService.IsMutant(dna, actualDateTime);
            Assert.IsTrue(isMutant);
            mock.Verify();
        }

        /// A T G C G A
        /// C T A A A A
        /// T T C T G T
        /// A G A A T G
        /// C C C C T A
        /// A C G T A A
        [Test]
        public void IsMutantWith2HorizontalSequences()
        {
            string[] dna = { "ATGCGA", "CTAAAA", "TTCTGT", "AGAATG", "CCCCTA", "ACGTAA" };

            mock.Setup(m => m.SaveOrUpdateLog(dna, true, actualDateTime)).Verifiable();

            var isMutant = mutantsIdentificationService.IsMutant(dna, actualDateTime);
            Assert.IsTrue(isMutant);
            mock.Verify();
        }

        /// A T G C G A
        /// C A G T G C
        /// T T A T G T
        /// A G A A G G
        /// C C C C T A
        /// T C A C T G
        [Test]
        public void IsMutantWith3Sequences()
        {
            string[] dna = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };

            mock.Setup(m => m.SaveOrUpdateLog(dna, true, actualDateTime)).Verifiable();

            var isMutant = mutantsIdentificationService.IsMutant(dna, actualDateTime);
            Assert.IsTrue(isMutant);
            mock.Verify();
        }
    }
}