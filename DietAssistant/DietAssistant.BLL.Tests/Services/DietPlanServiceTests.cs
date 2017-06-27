using DietAssistant.BLL.DietPlanStrategy;
using DietAssistant.BLL.Infrastructure.Automapper;
using DietAssistant.BLL.Services;
using DietAssistant.BLL.Tests.Infrastructure;
using DietAssistant.Core.Enums;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using DietAssistant.Entities;


namespace DietAssistant.BLL.Tests.Services
{
    public class DietPlanServiceTests
    {
        private DietPlanService _sut;
        private ReportDataClass _testData;

        [SetUp]
        public void SetUp()
        {
            AutoMapperConfiguration.Configure();
            var listOfStrategies = new List<IDietStrategy>
            {
                new CarbohydrateStrategy(),
                new FatStrategy(),
                new ProteinStrategy()
            };
            _sut = new DietPlanService(listOfStrategies);
            _testData = new ReportDataClass();
        }

        [Test]
        public void MakeAllSetsOfDishes_ReturnsBestDishes_WhenProteinBasedDietAndInputIsValid()
        {
            var diet = _sut.MakeAllSetsOfDishes(_testData.GetDishesForDiet.ToList(), DietStrategy.ProteinBased, 150);

            Assert.AreNotEqual(diet.Count(), 0);
        }

        [Test]
        public void MakeAllSetsOfDishes_ReturnsEmptyList_WhenProteinBasedDietAndInputIsNotValid()
        {
            var diet = _sut.MakeAllSetsOfDishes(_testData.GetDishesForDiet.ToList(), DietStrategy.ProteinBased, 10);

            Assert.AreEqual(diet.Count(), 0);
        }

        [Test]
        public void MakeAllSetsOfDishes_ReturnsBestDishes_WhenCarbohydrateBasedDietAndInputIsValid()
        {
            var diet = _sut.MakeAllSetsOfDishes(_testData.GetDishesForDiet.ToList(), DietStrategy.CarbohydrateBased,
                200);

            Assert.AreNotEqual(diet.Count(), 0);
        }

        [Test]
        public void MakeAllSetsOfDishes_ReturnsEmptyList_WhenCarbohydrateBasedDietAndInputIsNotValid()
        {
            var diet = _sut.MakeAllSetsOfDishes(_testData.GetDishesForDiet.ToList(), DietStrategy.CarbohydrateBased,
                10);

            Assert.AreEqual(diet.Count(), 0);
        }

        [Test]
        public void MakeAllSetsOfDishes_ReturnsBestDishes_WhenFatBasedDietAndInputIsValid()
        {
            var diet = _sut.MakeAllSetsOfDishes(_testData.GetDishesForDiet.ToList(), DietStrategy.FatBased, 70);

            Assert.AreNotEqual(diet.Count(), 0);
        }

        [Test]
        public void MakeAllSetsOfDishes_ReturnsEmptyList_WhenFatBasedDietAndInputIsNotValid()
        {
            var diet = _sut.MakeAllSetsOfDishes(_testData.GetDishesForDiet.ToList(), DietStrategy.FatBased, 10);

            Assert.AreEqual(diet.Count(), 0);
        }

        [Test]
        public void GetDietPlan_ReturnsDietPlan_WhenPlanExists()
        {
            var dietPlan = _sut.GetDietPlan(_testData.GetDishesForDiet.ToList());

            Assert.AreNotEqual(dietPlan.Dishes.Count, 0);
        }

        [Test]
        public void GetDietPlan_ReturnsEmptyDietPlan_WhenPlanDoesNotExist()
        {
            var dietPlan = _sut.GetDietPlan(new List<Dish>());

            Assert.AreEqual(dietPlan.Dishes.Count, 0);
        }

        [Test]
        public void GetDietPlan_ReturnsDietPlanWithoutWarning_WhenPlanExists()
        {
            var dietPlan = _sut.GetDietPlan(_testData.GetDishesForDiet.ToList());

            Assert.IsNull(dietPlan.Warning);
        }

        [Test]
        public void GetDietPlan_ReturnsDietPlanWithWarning_WhenPlanDoesNotExist()
        {
            var dietPlan = _sut.GetDietPlan(new List<Dish>());

            Assert.IsNotNull(dietPlan.Warning);
        }
    }
}
