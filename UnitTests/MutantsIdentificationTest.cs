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

        /// A T G C A G
        /// C T A C C G
        /// T A C A T C
        /// A G A A T C
        /// C T C A T C
        /// A C G T C A
        [Test]
        public void IsNotMutantWithNoSequence()
        {
            var isMutant = _mutantsIdentificationService.IsMutant(new string[] { "ATGCAG", "CTACCG", "TACATC", "AGAATC", "CTCATC" , "ACGTCA" });
            Assert.IsFalse(isMutant);
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
            var isMutant = _mutantsIdentificationService.IsMutant(new string[] { "ATGCAG", "CTAACG", "TACATC", "AGAATC", "CTCATC", "ACGTCA" });
            Assert.IsFalse(isMutant);
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
            var isMutant = _mutantsIdentificationService.IsMutant(new string[] { "ATGCAC", "CTAATC", "TACATC", "AGAATC", "CTCATC", "ACGTCA" });
            Assert.IsTrue(isMutant);
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
            var isMutant = _mutantsIdentificationService.IsMutant(new string[] { "ATGCGA", "ATAAAT", "TACAGT", "AGAATG", "CTCATA", "ACGTCA" });
            Assert.IsTrue(isMutant);
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
            var isMutant = _mutantsIdentificationService.IsMutant(new string[] { "ATGCGA", "CTAAAA", "TTCTGT", "ATAATG", "CCCATA", "ACGTAA" });
            Assert.IsTrue(isMutant);
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
            var isMutant = _mutantsIdentificationService.IsMutant(new string[] { "ATGCGA", "CTAAAA", "TTCTGT", "AGAATG", "CCCCTA", "ACGTAA" });
            Assert.IsTrue(isMutant);
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
            var isMutant = _mutantsIdentificationService.IsMutant(new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" });
            Assert.IsTrue(isMutant);
        }
    }
}
