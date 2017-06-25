using System;
using System.Collections.Generic;
using System.Linq;
using DietAssistant.BLL.Infrastructure.Automapper;
using DietAssistant.BLL.Infrastructure.Exceptions;
using DietAssistant.BLL.Interfaces;
using DietAssistant.BLL.Services;
using DietAssistant.BLL.Tests.Infrastructure;
using DietAssistant.Core.Enums;
using DietAssistant.Entities;
using DietAssistant.Interfaces;
using Moq;
using NUnit.Framework;

namespace DietAssistant.BLL.Tests.Services
{
    [TestFixture]
    public class ExtendedReportServiceTests
    {
        private IExtendedReportService _sut;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private ReportDataClass _testData;

        [SetUp]
        public void SetUp()
        {
            AutoMapperConfiguration.Configure();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _sut = new ExtendedReportService(_unitOfWorkMock.Object);
            _testData = new ReportDataClass();
        }


        [Test]
        public void GetDailyStatistic_ReturnsCorrectNumberOfReports_WhenDataExists()
        {
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Reports.Find(It.IsAny<Func<Report, bool>>()))
                .Returns(_testData.Reports.AsQueryable);

            var reports = _sut.GetDailyStatistic(DateTime.UtcNow);

            Assert.AreEqual(2, reports.Count());
        }

        [Test]
        public void GetAverageDailyReportByBodyType_ReturnsCorrectAverageAmount_WhenDataExists()
        {
            const int averageCarbonates = 20;
            const int averageFats = 20;
            const int averageProteins = 20;
            const BodyType type = BodyType.Ectomorph;
            var date = DateTime.UtcNow;
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Reports.Find(It.IsAny<Func<Report, bool>>()))
                .Returns(_testData.GetReportsWithType(date, type).AsQueryable);

            var report = _sut.GetAverageDailyReportByBodyType(date, type);

            Assert.AreEqual(averageCarbonates, report.AverageCarbohydrates);
            Assert.AreEqual(averageFats, report.AverageFats);
            Assert.AreEqual(averageProteins, report.AverageProteins);
        }


        [Test]
        public void GetAverageDailyReportByBodyType_ReturnsCorrectType_WhenDataExists()
        {
            const BodyType type = BodyType.Ectomorph;
            var date = DateTime.UtcNow;
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Reports.Find(It.IsAny<Func<Report, bool>>()))
                .Returns(_testData.GetReportsWithType(date, type).AsQueryable);

            var report = _sut.GetAverageDailyReportByBodyType(date, type);

            Assert.AreEqual(type, report.Type);
        }

        [Test]
        public void GetAverageDailyReportByBodyType_ThrowsEntityNotFoundException_WhenReportsAreAbsent()
        {
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Reports.Find(It.IsAny<Func<Report, bool>>()))
                .Returns(new List<Report>().AsQueryable);

            Assert.Throws<EntityNotFoundException>(
                () => _sut.GetAverageDailyReportByBodyType(DateTime.UtcNow, BodyType.Ectomorph));
        }
    }
}
