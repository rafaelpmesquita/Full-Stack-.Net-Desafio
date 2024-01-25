using Azure.Core;
using MediatR;
using TesteNetCore.API.Service.Interface;
using TesteNetCore.Application.Mapper;
using TesteNetCore.Domain.Entities;
using TesteNetCore.Domain.Enum;
using TesteNetCore.Domain.Repository.Interface;

namespace TesteNetCore.API.Service
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IObjectConverter _objectConverter;

        public LeadService(ILeadRepository leadRepository, IObjectConverter objectConverter)
        {
            _leadRepository = leadRepository;
            _objectConverter = objectConverter;
        }
        public async Task<List<LeadIncompleteModel>> GetPendingLeads()
        {
            try
            {
                List<Lead> pendingLeads = (await _leadRepository.GetLeads())
                        .Where(x => x.StatusLeadId == Domain.Enum.LeadStatus.Pending).ToList();
                return _objectConverter.Map<List<LeadIncompleteModel>>(pendingLeads);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Lead>> GetAcceptedLeads()
        {
            try
            {
                List<Lead> pendingLeads = (await _leadRepository.GetLeads()).ToList()
                        .Where(x => x.StatusLeadId == Domain.Enum.LeadStatus.Accepted).ToList();
                return pendingLeads;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ChangeLeadStatus(LeadIncompleteModel request)
        {
            try
            {
                Lead? lead = (await _leadRepository.GetLeads()).FirstOrDefault(x => x.Id == request.Id);
                if (lead == null)
                {
                    throw new InvalidOperationException("Lead not found.");
                }
                if (lead.StatusLeadId != LeadStatus.Pending)    
                {
                    throw new InvalidOperationException("Lead Status is not pending.");
                }
                if (request.StatusLeadId == LeadStatus.Accepted)
                {
                    lead.Price = lead.Price > 500 ? lead.Price * (decimal)0.9 : lead.Price;
                }
                lead.StatusLeadId = request.StatusLeadId;
                return await _leadRepository.UpdateLead(lead);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
