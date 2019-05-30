using ExamenMercadolibreMutantes.Dal;
using ExamenMercadolibreMutantes.Models;
using ExamenMercadolibreMutantes.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    class AnalysisLogServiceTest
    {

        AnalysisLogService analysisLogService;
        Mock<IAnalysisLogDal> mock;
        [SetUp]
        public void Setup()
        {
            mock = new Mock<IAnalysisLogDal>();
            analysisLogService = new AnalysisLogService(mock.Object);
        }

        [Test]
        public void TestStatisticsWithMoreHumansThanMutants()
        {
            mock.Setup(m => m.GetHumanSum()).Returns(100);
            mock.Setup(m => m.GetMutantSum()).Returns(40);

            var statistics = analysisLogService.GetStatistics();

            Assert.AreEqual(100, statistics.HumanDnaCount);
            Assert.AreEqual(40, statistics.MutantDnaCount);
            Assert.AreEqual(0.4M, statistics.Ratio);
        }

        [Test]
        public void TestStatisticsWithMoreMutansThanHumans()
        {
            mock.Setup(m => m.GetHumanSum()).Returns(40);
            mock.Setup(m => m.GetMutantSum()).Returns(100);

            var statistics = analysisLogService.GetStatistics();

            Assert.AreEqual(40, statistics.HumanDnaCount);
            Assert.AreEqual(100, statistics.MutantDnaCount);
            Assert.AreEqual(2.5M, statistics.Ratio);
        }

        [Test]
        public void TestStatisticsWithNoHumans()
        {
            mock.Setup(m => m.GetHumanSum()).Returns(0);

            mock.Setup(m => m.GetMutantSum()).Returns(40);

            var statistics = analysisLogService.GetStatistics();

            Assert.AreEqual(0, statistics.HumanDnaCount);
            Assert.AreEqual(40, statistics.MutantDnaCount);
            Assert.AreEqual(0, statistics.Ratio);
        }

        [Test]
        public void TestStatisticsWithNoMutants()
        {
            mock.Setup(m => m.GetHumanSum()).Returns(50);

            mock.Setup(m => m.GetMutantSum()).Returns(0);

            var statistics = analysisLogService.GetStatistics();

            Assert.AreEqual(50, statistics.HumanDnaCount);
            Assert.AreEqual(0, statistics.MutantDnaCount);
            Assert.AreEqual(0, statistics.Ratio);
        }


        [Test]
        public void TestSaveNewLog()
        {
            var mutantDna = new string[] { "ATGCGA", "CTAAAA", "TTCTGT", "ATAATG", "CCCATA", "ACGTAA" };

            MutantAnalysisLog notExistingLog = null;

            mock.Setup(m => m.GetExistingLog(mutantDna)).Returns(notExistingLog).Verifiable();
            mock.Setup(m => m.CreateNewLog(mutantDna, true)).Verifiable();

            analysisLogService.SaveOrUpdateLog(mutantDna, true, DateTime.Now);


            mock.Verify();
            
        }

        [Test]
        public void TestUpdateExistingLog()
        {
            var actualDateTime = DateTime.Now;
            var mutantDna = new string[] { "ATGCGA", "CTAAAA", "TTCTGT", "ATAATG", "CCCATA", "ACGTAA" };

            MutantAnalysisLog existingLog =
                new MutantAnalysisLog { Id = 1, Count = 1, CreateDttm = actualDateTime.AddDays(-1), Dna = mutantDna, IsMutant = true, UpdateDttm = actualDateTime.AddDays(-1) };

            MutantAnalysisLog updatedLog =
                                new MutantAnalysisLog { Id = 1, Count = 2, CreateDttm = actualDateTime.AddDays(-1), Dna = mutantDna, IsMutant = true, UpdateDttm = actualDateTime };


            mock.Setup(m => m.GetExistingLog(mutantDna)).Returns(existingLog).Verifiable();
            mock.Setup(m => m.UpdateLog(updatedLog)).Verifiable();

            analysisLogService.SaveOrUpdateLog(mutantDna, true, actualDateTime);


            mock.Verify();

        }

    }
}
