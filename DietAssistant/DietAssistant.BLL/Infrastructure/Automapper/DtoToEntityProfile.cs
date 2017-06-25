using AutoMapper;
using DietAssistant.BLL.Dto;
using DietAssistant.Entities;

namespace DietAssistant.BLL.Infrastructure.Automapper
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<DishDto, Dish>();
            CreateMap<UserDishDto, UserDish>();
            CreateMap<ReportDto, Report>();
        }
    }
}
