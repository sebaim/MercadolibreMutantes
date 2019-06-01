using ExamenMercadolibreMutantes.Dal;
using ExamenMercadolibreMutantes.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests
{
    class TestAnalysisLogDal
    {

        AnalysisLogDal analysisLogDal;
        Mock<DbSet<MutantAnalysisLog>> mockSet;
        Mock<MutantsDbContext> mockContext;

        [SetUp]
        public void Setup()
        {

            var mutantAnalysisLogs = new List<MutantAnalysisLog>
            {
               new MutantAnalysisLog {Dna = new string[] {"AAA" }, IsMutant = true, Count = 1},
               new MutantAnalysisLog {Dna = new string[] {"BBB" }, IsMutant = true, Count = 2},
               new MutantAnalysisLog {Dna = new string[] {"CCC"}, IsMutant = false, Count = 1},
               new MutantAnalysisLog {Dna = new string[] {"DDD" }, IsMutant = false, Count = 2},
               new MutantAnalysisLog {Dna = new string[] {"EEE" }, IsMutant = false, Count = 1}
            }.AsQueryable();


            mockSet = new Mock<DbSet<MutantAnalysisLog>>();
            mockSet.As<IQueryable<MutantAnalysisLog>>().Setup(m => m.Provider).Returns(mutantAnalysisLogs.Provider);
            mockSet.As<IQueryable<MutantAnalysisLog>>().Setup(m => m.Expression).Returns(mutantAnalysisLogs.Expression);
            mockSet.As<IQueryable<MutantAnalysisLog>>().Setup(m => m.ElementType).Returns(mutantAnalysisLogs.ElementType);
            mockSet.As<IQueryable<MutantAnalysisLog>>().Setup(m => m.GetEnumerator()).Returns(mutantAnalysisLogs.GetEnumerator());

            mockContext = new Mock<MutantsDbContext>();           

            mockContext.Setup(m => m.MutantAnalysisLogs).Returns(mockSet.Object);

            analysisLogDal = new AnalysisLogDal(mockContext.Object);

        }



        [Test]
        public void TestGetHumanSum()
        {
            var humanSum = analysisLogDal.GetHumanSum();

            Assert.AreEqual(4, humanSum);

        }

        [Test]
        public void TestGetMutanSum()
        {
            var mutantSum = analysisLogDal.GetMutantSum();
            Assert.AreEqual(3, mutantSum);
        }

        [Test]
        public void TestFoundExistingLog()
        {
            var analysisLog = analysisLogDal.GetExistingLog( new string[] { "BBB" });
            
            Assert.AreEqual(new string[] { "BBB" }, analysisLog.Dna);
        }

        [Test]
        public void TestNotFoundExistingLog()
        {
            var analysisLog = analysisLogDal.GetExistingLog(new string[] { "BBA" });
            Assert.AreEqual(null, analysisLog);
        }

        [Test]

        public void TestAddMutantAnalysis ()
        {
            DateTime actualDateTime = DateTime.Now;

            var dna = new string[] { "AAABC" };

            MutantAnalysisLog logToSave = new MutantAnalysisLog { Count = 1, CreateDttm = actualDateTime, UpdateDttm = actualDateTime, Dna = dna, IsMutant = true };

            analysisLogDal.CreateNewLog(dna, true, actualDateTime);

          
            mockSet.Verify(m => m.Add(logToSave), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void TestUpdateMutantAnalysis()
        {
            DateTime actualDateTime = DateTime.Now;

            var dna = new string[] { "AAABC" };

            MutantAnalysisLog logToSave = new MutantAnalysisLog { Count = 1, CreateDttm = actualDateTime, UpdateDttm = actualDateTime, Dna = dna, IsMutant = true };

            analysisLogDal.UpdateLog(logToSave);


            mockSet.Verify(m => m.Update(logToSave), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

    }
}
