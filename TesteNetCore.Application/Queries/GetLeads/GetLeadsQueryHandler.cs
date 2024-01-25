using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNetCore.Application.Mapper;
using TesteNetCore.Domain.Enum;
using TesteNetCore.Domain.Repository.Interface;

namespace TesteNetCore.Application.Queries.GetLeads
{
    public class GetLeadsQueryHandler : IRequestHandler<GetLeadsQuery, List<GetLeadsViewModel>>
    {
        private readonly ILeadRepository _repository;
        private readonly IObjectConverter _mapper;

        public GetLeadsQueryHandler(ILeadRepository repository, IObjectConverter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetLeadsViewModel>> Handle(GetLeadsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<GetLeadsViewModel> leads = _mapper
                    .Map<List<GetLeadsViewModel>>(await _repository.GetLeads())
                    .Where(x=>x.StatusLeadId==LeadStatus.Pending)
                    .ToList();
                return await Task.FromResult(leads);

            }catch(Exception e)
            {
                throw e;
            }
        }
    }
}
