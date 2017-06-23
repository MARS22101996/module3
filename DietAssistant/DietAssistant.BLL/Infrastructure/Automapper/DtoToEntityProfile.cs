using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
