using DietAssistant.Context;
using DietAssistant.Entities;
using DietAssistant.UnitOfWorks;
using Moq;
using NUnit.Framework;
using System.Data.Entity;

namespace DietAssistant.Repositories.Tests
{
    public class ReportRepositoryTests
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
            var reportSet = new Mock<DbSet<Report>>();
            _mockContext.Setup(context => context.Set<Report>()).Returns(reportSet.Object);
            _mockContext.Setup(context => context.Set<Report>().Add(It.IsAny<Report>())).Verifiable();

            _uow.Reports.Create(new Report());

            _mockContext.Verify(x => x.Set<Report>().Add(It.IsAny<Report>()));

        }

        [Test]
        public void Create_DeletesReport_WhenReportExists()
        {
            var reportSet = new Mock<DbSet<Report>>();
            var report = new Report { Id = 1 };
            _mockContext.Setup(context => context.Set<Report>()).Returns(reportSet.Object);
            _mockContext.Setup(context => context.Set<Report>().Find(It.IsAny<int>())).Returns(report);

            _uow.Reports.Delete(report.Id);

            _mockContext.Verify(x => x.Set<Report>().Remove(It.IsAny<Report>()));

        }
    }
}
