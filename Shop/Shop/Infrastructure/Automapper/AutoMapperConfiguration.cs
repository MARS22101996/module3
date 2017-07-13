using AutoMapper;
using Shops.BLL.Infrastructure.Automapper;

namespace Shop.Infrastructure.Automapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DtoToEntityProfile>();
                x.AddProfile<EntityToDtoProfile>();
            });
        }
    }
}
