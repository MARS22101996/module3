using AutoMapper;
using DietAssistant.BLL.Dto;
using DietAssistant.Entities;

namespace DietAssistant.BLL.Infrastructure.Automapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Dish, DishDto>();
            CreateMap<UserDish, UserDishDto>();
            CreateMap<Report, ReportDto>();
        }
    }
}
