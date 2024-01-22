
using TesteNetCore.Application.Commands.ChangeStatus;
using TesteNetCore.Application.Queries.GetLeads;
using TesteNetCore.Domain.Entities;

namespace TesteNetCore.Application.Mapper.Profile
{
    public class ViewToEntity : AutoMapper.Profile
    {
        public ViewToEntity()
        {
            CreateMap<Leads, GetLeadsViewModel>().ReverseMap();
            CreateMap<Leads, GetAcceptedLeadsViewModel>().ReverseMap();
            CreateMap<Leads, ChangeStatusLeadCommand>().ReverseMap();
        }
    }
}
