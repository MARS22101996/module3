using System;
using System.Collections.Generic;
using System.Linq;
using DietAssistant.BLL.Dto;
using DietAssistant.BLL.Infrastructure.Automapper;
using DietAssistant.BLL.Interfaces;
using DietAssistant.BLL.Services;
using DietAssistant.BLL.Tests.Infrastructure;
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
        private UserDto _testUser;
        private List<Dish> _testDishes;
        private ReportDataClass _testData;

        [SetUp]
        public void SetUp()
        {
            AutoMapperConfiguration.Configure();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _sut = new ReportService(_unitOfWorkMock.Object);
             _testData = new ReportDataClass();
            _testUser = _testData.User;
            _testDishes = _testData.GetDishes.ToList();
        }


        [Test]
        public void SaveReport_CallsCreateFromDal_WhenReportIsValid()
        {
            var model = new ReportDto {Id = 1, Date = DateTime.UtcNow, Carbohydrates = 1, Fats = 2, Proteins = 3};
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.Reports.Create(It.IsAny<Report>()));

            _sut.SaveReport(model);

            _unitOfWorkMock.Verify(unitOfWork => unitOfWork.Reports.Create(It.IsAny<Report>()), Times.Once);
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
        public void GetReportForUser_ReturnsReportWithoutViolations_WhenViolationsAreAbsent()
        {
            var date = DateTime.UtcNow;
            var dishesOfUser = _testData.GetUserDishes(_testDishes, date, _testUser.Id);
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.UserDishes.Find(It.IsAny<Func<UserDish, bool>>()))
                .Returns(dishesOfUser.AsQueryable);

            var report = _sut.GetReportForUser(date, _testUser);

            Assert.IsNull(report.WarningByCarbohydrates);
            Assert.IsNull(report.WarningByFats);
            Assert.IsNull(report.WarningByProteins);
        }
        [Test]
        public void GetReportForUser_ReturnsNull_WhenUserDoesNotHaveDishes()
        {
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.UserDishes.Find(It.IsAny<Func<UserDish, bool>>()))
                .Returns(new List<UserDish>().AsQueryable());         

            var report = _sut.GetReportForUser(DateTime.UtcNow, _testUser);
        
            Assert.IsNull(report);       
        }

        [Test]
        public void GetReportForUser_ReturnsReportWithRightSum_WhenDataExists()
        {
            var dishesOfUser = _testData.GetUserDishes(_testDishes, DateTime.UtcNow, _testUser.Id).ToList();
            var sumOfCarbonates = dishesOfUser.Sum(x => x.Dish.CarbohydratesPer100Grams * (x.Grams / 100.0));
            var sumOfFats = dishesOfUser.Sum(x => x.Dish.FatsPer100Grams * (x.Grams / 100.0));
            var sumOfProteins = dishesOfUser.Sum(x => x.Dish.ProteinsPer100Grams * (x.Grams / 100.0));
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.UserDishes.Find(It.IsAny<Func<UserDish, bool>>()))
                .Returns(_testData.GetUserDishes(_testDishes, DateTime.UtcNow, _testUser.Id).AsQueryable);           

            var report = _sut.GetReportForUser(DateTime.UtcNow, _testUser);

            Assert.AreEqual(report.Carbohydrates, sumOfCarbonates);
            Assert.AreEqual(report.Fats, sumOfFats);
            Assert.AreEqual(report.Proteins, sumOfProteins);
        }

        [Test]
        public void GetReportForUser_ReturnsReportWithRightDate_WhenDataExists()
        {
            var date = DateTime.UtcNow;
            var dishesOfUser = _testData.GetUserDishes(_testDishes, date, _testUser.Id);
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.UserDishes.Find(It.IsAny<Func<UserDish, bool>>()))
                .Returns(dishesOfUser.AsQueryable);            

            var report = _sut.GetReportForUser(date, _testUser);

            Assert.AreEqual(date, report.Date);
        }

        [Test]
        public void GetReportForUser_ReturnsReportWithRightUser_WhenDataExists()
        {
            var date = DateTime.UtcNow;
            var dishesOfUser = _testData.GetUserDishes(_testDishes, date, _testUser.Id);
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.UserDishes.Find(It.IsAny<Func<UserDish, bool>>()))
                .Returns(dishesOfUser.AsQueryable);            

            var report = _sut.GetReportForUser(date, _testUser);

            Assert.AreEqual(_testUser.Id, report.UserId);
        }

        [Test]
        public void GetReportForUser_ReturnsReportWithViolationsByCarbohydrates_WhenViolationByCarbohydrates()
        {
            var date = DateTime.UtcNow;
            var dishesOfUser = _testData.GetUserDishesWithViolations(_testDishes, date, _testUser.Id);
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.UserDishes.Find(It.IsAny<Func<UserDish, bool>>()))
                .Returns(dishesOfUser.AsQueryable);          

            var report = _sut.GetReportForUser(date, _testUser);

            Assert.IsNotNull(report.WarningByCarbohydrates);          
        }

        [Test]
        public void GetReportForUser_ReturnsReportWithViolationsByFats_WhenViolationByFats()
        {
            var date = DateTime.UtcNow;
            var dishesOfUser = _testData.GetUserDishesWithViolations(_testDishes, date, _testUser.Id);
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.UserDishes.Find(It.IsAny<Func<UserDish, bool>>()))
                .Returns(dishesOfUser.AsQueryable);         

            var report = _sut.GetReportForUser(date, _testUser);

            Assert.IsNotNull(report.WarningByFats);
        }

        [Test]
        public void GetReportForUser_ReturnsReportWithViolationsByProteins_WhenViolationsByProteins()
        {
            var date = DateTime.UtcNow;
            var dishesOfUser = _testData.GetUserDishesWithViolations(_testDishes, date, _testUser.Id);
            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.UserDishes.Find(It.IsAny<Func<UserDish, bool>>()))
                .Returns(dishesOfUser.AsQueryable);           

            var report = _sut.GetReportForUser(date, _testUser);

            Assert.IsNotNull(report.WarningByProteins);
        }
    }
}
