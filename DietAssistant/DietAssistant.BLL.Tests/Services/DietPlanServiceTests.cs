using DietAssistant.BLL.DietPlanStrategy;
using DietAssistant.BLL.Infrastructure.Automapper;
using DietAssistant.BLL.Services;
using DietAssistant.BLL.Tests.Infrastructure;
using DietAssistant.Core.Enums;
using DietAssistant.Entities;
using DietAssistant.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;


namespace DietAssistant.BLL.Tests.Services
{
    public class DietPlanServiceTests
    {
        private DietPlanService _sut;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private ReportDataClass _testData;
        private List<Dish> _testDishes;

        [SetUp]
        public void SetUp()
        {
            AutoMapperConfiguration.Configure();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            var list = new List<IDietStrategy>
            {
                new CarbohydrateStrategy(),
                new FatStrategy(),
                new ProteinStrategy()
            };
            _sut = new DietPlanService(list);
            _testData = new ReportDataClass();
           
        }
        [Test]
        public void MakeAllSetsOfDishes_ReturnsBestDishes_WhenDishesExists()
        {
            var diet = _sut.MakeAllSetsOfDishes(_testData.GetDishesForDiet.ToList(), DietStrategy.ProteinBased,150);

            Assert.AreNotEqual(diet.Count(), 0);
        }

        [Test]
        public void MakeAllSetsOfDishes_ReturnsBestDishes_WhenDishesExist1()
        {
            var diet = _sut.MakeAllSetsOfDishes(_testData.GetDishesForDiet.ToList(), DietStrategy.ProteinBased, 10);

            Assert.AreEqual(diet.Count(), 0);
        }
    }
}
