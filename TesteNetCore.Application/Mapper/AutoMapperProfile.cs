using AutoMapper;
using TesteNetCore.Application.Mapper.Profile;
using TesteNetCore.Application.Queries.GetLeads;
using TesteNetCore.Domain.Entities;
namespace TesteNetCore.Application.Mapper
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public static MapperConfiguration RegisterMappings(params AutoMapper.Profile[] profiles)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ViewToEntity());
            });
        }
    }
}
