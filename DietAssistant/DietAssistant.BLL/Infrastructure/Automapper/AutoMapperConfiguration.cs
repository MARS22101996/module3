using AutoMapper;

namespace DietAssistant.BLL.Infrastructure.Automapper
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
