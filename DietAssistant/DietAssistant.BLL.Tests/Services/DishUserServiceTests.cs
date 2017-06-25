using System;
using DietAssistant.BLL.Dto;
using DietAssistant.BLL.Infrastructure.Automapper;
using NUnit.Framework;
using DietAssistant.BLL.Interfaces;
using DietAssistant.BLL.Services;
using DietAssistant.Entities;
using DietAssistant.Interfaces;
using Moq;

namespace DietAssistant.BLL.Tests.Services
{
    [TestFixture]
    public class DishUserServiceTests
    {
        private IDishUserService _sut;
        private Mock<IUnitOfWork> _unitOfWorkMock;

        [SetUp]
        public void SetUp()
        {
            AutoMapperConfiguration.Configure();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _sut = new DishUserService(_unitOfWorkMock.Object);
        }


        [Test]
        public void Create_CallsCreateFromDal_WhenUserDishIsValid()
        {
            var model = new UserDishDto { Id = 1, Date = DateTime.UtcNow, DishId = 1, UserId = 1, Grams = 100};

            _unitOfWorkMock.Setup(unitOfWork => unitOfWork.UserDishes.Create(It.IsAny<UserDish>()));

            _sut.Create(model);

            _unitOfWorkMock.Verify(unitOfWork => unitOfWork.UserDishes.Create(It.IsAny<UserDish>()), Times.Once);
        }
    }
}
