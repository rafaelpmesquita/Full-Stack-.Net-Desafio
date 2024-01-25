using AutoMapper;
using MediatR;
using TesteNetCore.Application.Mapper;
using TesteNetCore.Application.Queries.GetLeads;
using TesteNetCore.Domain.Entities;
using TesteNetCore.Domain.Enum;
using TesteNetCore.Domain.Repository.Interface;

namespace TesteNetCore.Application.Commands.ChangeStatus
{
    public class ChangeStatusLeadHandler : IRequestHandler<ChangeStatusLeadCommand, Unit>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IObjectConverter _mapper;
        public ChangeStatusLeadHandler(ILeadRepository _eadRepository, IObjectConverter mapper)
        {
            _leadRepository = _eadRepository;
            _mapper = mapper;

        }
        public async Task<Unit> Handle(ChangeStatusLeadCommand request, CancellationToken cancellationToken)
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
                    lead.Price = lead.Price > 500 ? lead.Price * (decimal)0.9 : 500;
                }
                lead.StatusLeadId = request.StatusLeadId;
                await _leadRepository.UpdateLead(lead);
                return await Task.FromResult(Unit.Value);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
