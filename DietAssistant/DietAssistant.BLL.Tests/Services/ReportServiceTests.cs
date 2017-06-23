using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietAssistant.BLL.Dto;
using DietAssistant.BLL.Infrastructure.Automapper;
using DietAssistant.BLL.Interfaces;
using DietAssistant.BLL.Services;
using DietAssistant.Entities;
using DietAssistant.Interfaces;
using Moq;
using NUnit.Framework;

namespace DietAssistant.BLL.Tests.Services
{

    [TestFixture]
    class ReportServiceTests
    {
            private IReportService _sut;
            private Mock<IUnitOfWork> _unitOfWorkMock;

            [SetUp]
            public void SetUp()
            {
                AutoMapperConfiguration.Configure();
                _unitOfWorkMock = new Mock<IUnitOfWork>();
                _sut = new ReportService(_unitOfWorkMock.Object);
            }


            [Test]
            public void SaveReport_CallsCreateFromDal_WhenReportIsValid()
            {
                var model = new ReportDto { Id = 1, Date = DateTime.UtcNow, Carbohydrates = 1, Fats = 2, Proteins = 3};

                _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Reports.Create(It.IsAny<Report>()));

                _sut.SaveReport(model);

                _unitOfWorkMock.Verify(unitOfWork => unitOfWork.Reports.Create(It.IsAny<Report>()), Times.Once);
            }

    }
}
