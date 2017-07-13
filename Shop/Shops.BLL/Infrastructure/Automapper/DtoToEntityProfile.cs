using AutoMapper;
using Shops.BLL.Dto;
using Shops.DAL.Entities;

namespace Shops.BLL.Infrastructure.Automapper
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<BrandDto, Brand>();
        }
    }
}
