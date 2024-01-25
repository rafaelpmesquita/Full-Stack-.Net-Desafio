using MediatR;
using TesteNetCore.Application.Mapper;
using TesteNetCore.Domain.Enum;
using TesteNetCore.Domain.Exceptions;
using TesteNetCore.Domain.Repository.Interface;

namespace TesteNetCore.Application.Queries.GetLeads
{
    public class GetAcceptedLeadsQueryHandler : IRequestHandler<GetAcceptedLeadsQuery, List<GetAcceptedLeadsViewModel>>
    {
        private readonly ILeadRepository _repository;
        private readonly IObjectConverter _mapper;

        public GetAcceptedLeadsQueryHandler(ILeadRepository repository, IObjectConverter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetAcceptedLeadsViewModel>> Handle(GetAcceptedLeadsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<GetAcceptedLeadsViewModel> leads = _mapper
                    .Map<List<GetAcceptedLeadsViewModel>>(await _repository.GetLeads())
                    .Where(x=>x.StatusLeadId == LeadStatus.Accepted)
                    .ToList();
                return await Task.FromResult(leads);

            }catch(CustomLeadException ex)
            {
                Console.WriteLine($"Exception Title: {ex.Title}");
                Console.WriteLine($"Exception Custom Message: {ex.CustomMessage}");
                throw;
            }
        }
    }
}
