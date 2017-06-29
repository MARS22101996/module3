using DietAssistant.Context;
using DietAssistant.Entities;
using DietAssistant.Tests;
using DietAssistant.UnitOfWorks;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DietAssistant.Repositories.Tests
{
    public class ReportRepositoryTests : TestBase
    {
        private UnitOfWork _uow;
        private Mock<DietAssistantContext> _mockContext;

        [SetUp]
        public void SetUp()
        {
            _mockContext = new Mock<DietAssistantContext>();
            _uow = new UnitOfWork(_mockContext.Object);
        }

        [Test]
        public void Create_CreatesReport_WhenInputIsReport()
        {
            var reportSet = GetDbSetMock(new List<Report>());
            _mockContext.Setup(context => context.Set<Report>()).Returns(reportSet.Object);
            _mockContext.Setup(context => context.Set<Report>().Add(It.IsAny<Report>())).Verifiable();

            _uow.Reports.Create(new Report());

            _mockContext.Verify(x => x.Set<Report>().Add(It.IsAny<Report>()));

        }

        [Test]
        public void Create_DeletesReport_WhenReportExists()
        {
            var reportSet = GetDbSetMock(new List<Report>());
            var report = new Report { Id = 1 };
            _mockContext.Setup(context => context.Set<Report>()).Returns(reportSet.Object);
            _mockContext.Setup(context => context.Set<Report>().Find(It.IsAny<int>())).Returns(report);

            _uow.Reports.Delete(report.Id);

            _mockContext.Verify(x => x.Set<Report>().Remove(It.IsAny<Report>()));

        }
    }
}
