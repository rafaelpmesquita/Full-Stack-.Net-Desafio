using MediatR;
using TesteNetCore.Domain.Entities;

namespace TesteNetCore.API.Service.Interface
{
    public interface ILeadService
    {
        Task<List<LeadIncompleteModel>> GetPendingLeads();
        Task<List<Lead>> GetAcceptedLeads();
        Task<Unit> ChangeLeadStatus(LeadIncompleteModel request);
    }
}
