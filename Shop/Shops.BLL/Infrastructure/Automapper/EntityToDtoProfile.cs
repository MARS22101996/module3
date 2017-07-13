using AutoMapper;
using Shops.BLL.Dto;
using Shops.DAL.Entities;

namespace Shops.BLL.Infrastructure.Automapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Brand, BrandDto>();
        }
    }
}
