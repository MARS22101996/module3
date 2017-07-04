using DietAssistant.Context;
using DietAssistant.Entities;
using DietAssistant.UnitOfWorks;
using Moq;
using NUnit.Framework;
using System.Data.Entity;

namespace DietAssistant.Tests.Repositories
{
    public class UserDishRepositoryTests
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
        public void Create_CreatesUserDish_WhenInputIsUserDish()
        {
            var reportSet = new Mock<DbSet<UserDish>>();
            _mockContext.Setup(context => context.Set<UserDish>()).Returns(reportSet.Object);
            _mockContext.Setup(context => context.Set<UserDish>().Add(It.IsAny<UserDish>())).Verifiable();

            _uow.UserDishes.Create(new UserDish());

            _mockContext.Verify(x => x.Set<UserDish>().Add(It.IsAny<UserDish>()));
        }

        [Test]
        public void Create_DeletesUserDish_WhenUserDishExists()
        {
            var userDishSet = new Mock<DbSet<UserDish>>();
            var userDish = new UserDish { Id = 1 };
            _mockContext.Setup(context => context.Set<UserDish>()).Returns(userDishSet.Object);
            _mockContext.Setup(context => context.Set<UserDish>().Find(It.IsAny<int>())).Returns(userDish);

            _uow.UserDishes.Delete(userDish.Id);

            _mockContext.Verify(x => x.Set<UserDish>().Remove(It.IsAny<UserDish>()));
        }
    }
}