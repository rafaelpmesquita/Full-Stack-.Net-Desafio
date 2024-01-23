
using TesteNetCore.Application.Commands.ChangeStatus;
using TesteNetCore.Application.Queries.GetLeads;
using TesteNetCore.Domain.Entities;

namespace TesteNetCore.Application.Mapper.Profile
{
    public class ViewToEntity : AutoMapper.Profile
    {
        public ViewToEntity()
        {
            CreateMap<Lead, ChangeStatusLeadCommand>().ReverseMap();
            CreateMap<Lead, LeadIncompleteModel>().ReverseMap();
            CreateMap<Lead, GetLeadsViewModel>().ReverseMap();
            CreateMap<Lead, GetAcceptedLeadsViewModel>().ReverseMap(); 
        }
    }
}
