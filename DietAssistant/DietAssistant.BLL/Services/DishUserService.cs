using AutoMapper;
using DietAssistant.BLL.Dto;
using DietAssistant.BLL.Interfaces;
using DietAssistant.Entities;
using DietAssistant.Interfaces;

namespace DietAssistant.BLL.Services
{
    public class DishUserService : IDishUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DishUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(UserDishDto userDishDto)
        {
            var userDish = Mapper.Map<UserDish>(userDishDto);

            _unitOfWork.UserDishes.Create(userDish);

            _unitOfWork.Save();
        }
    }
}
