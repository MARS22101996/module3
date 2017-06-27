using DietAssistant.Context;
using DietAssistant.Entities;
using DietAssistant.UnitOfWorks;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DietAssistant.Tests.Repositories
{
    public class UserRepositoryTests
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
        public void Create_CreatesUser_WhenInputIsUser()
        {
            var reportSet = GetDbSetMock(new List<User>());
            _mockContext.Setup(context => context.Set<User>()).Returns(reportSet.Object);
            _mockContext.Setup(context => context.Set<User>().Add(It.IsAny<User>())).Verifiable();

            _uow.Users.Create(new User());

            _mockContext.Verify(x => x.Set<User>().Add(It.IsAny<User>()));
        }

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