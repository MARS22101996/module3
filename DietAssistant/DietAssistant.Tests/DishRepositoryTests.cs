using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DietAssistant.Context;
using DietAssistant.Entities;
using DietAssistant.UnitOfWorks;
using Moq;
using NUnit.Framework;

namespace DietAssistant.Tests
{
    [TestFixture]
    public class DishRepositoryTests
    {
        private UnitOfWork _uow;
        private DietAssistantContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new DietAssistantContext();
            _uow = new UnitOfWork(_context);
        }

        [Test]
        public void GetAll_ReturnsDishes_WhenGettingDishes()
        {
            var dishes = _uow.Dishes.GetAll().ToList();

            Assert.AreNotEqual(0, dishes.Count);
        }

        [Test]
        public void Get_ReturnsDish_WhenGettingDish()
        {
            var dish = _uow.Dishes.Get(2);

            Assert.AreEqual(2, dish.Id);
        }

        [Test]
        public void Create_CreatesDish_WhenDishIsAdded()
        {
            var dish = new Dish()
            {
                Name = "test",
                CarbohydratesPer100Grams = 30,
                FatsPer100Grams = 30,
                ProteinsPer100Grams = 30
            };

            _uow.Dishes.Create(dish);
            _uow.Save();
            var checkAfterCreationOfDish = _uow.Dishes.Find(x => x.Name.Equals("test")).First();

            Assert.AreEqual(dish.Name, checkAfterCreationOfDish.Name);
        }

        [Test]
        public void Update_UpdatesDish_WhenDishIsUpdated()
        {
            var dish = _uow.Dishes.Get(2);
            var oldName = dish.Name;
            dish.Name = "new-name";
            _uow.Dishes.Update(dish);
            _uow.Save();
            var newName = _uow.Dishes.Get(2).Name;

            Assert.AreNotEqual(oldName, newName);
        }

        [Test]
        public void Delete_DeletesDish_WhenDishIsDeleted()
        {
            var oldDish = _uow.Dishes.Get(1);
            _uow.Dishes.Delete(1);
            _uow.Save();
            var newDish = _uow.Dishes.Get(1);

            Assert.IsNotNull(oldDish);
            Assert.IsNull(newDish);
        }


        //[Test]
        //public void Create_CreatesDish_WhenInputIsDish()
        //{
        //    var dishSet = GetDbSetMock(new List<Dish>());
        //    _mockContext.Setup(context => context.Set<Dish>()).Returns(dishSet.Object);
        //    _mockContext.Setup(context => context.Set<Dish>().Add(It.IsAny<Dish>())).Verifiable();
          
        //    _uow.Dishes.Create(new Dish());

        //    _mockContext.Verify(x => x.Set<Dish>().Add(It.IsAny<Dish>()));

        //}

        //[Test]
        //public void Create_DeletesDish_WhenDishExists()
        //{
        //    var dishSet = GetDbSetMock(new List<Dish>());
        //    var dish = new Dish { Id = 1 };
        //    _mockContext.Setup(context => context.Set<Dish>()).Returns(dishSet.Object);
        //    _mockContext.Setup(context => context.Set<Dish>().Find(It.IsAny<int>())).Returns(dish);

        //    _uow.Dishes.Delete(dish.Id);

        //    _mockContext.Verify(x => x.Set<Dish>().Remove(It.IsAny<Dish>()));

        //}


        private static Mock<DbSet<T>> GetDbSetMock<T>(IEnumerable<T> items = null) where T : class
        {
            if (items == null)
            {
                items = new T[0];
            }

            var dbSetMock = new Mock<DbSet<T>>();
            var q = dbSetMock.As<IQueryable<T>>();

            q.Setup(x => x.GetEnumerator()).Returns(items.GetEnumerator);

            return dbSetMock;
        }

    }
}