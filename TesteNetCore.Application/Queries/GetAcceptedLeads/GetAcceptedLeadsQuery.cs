using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteNetCore.Application.Queries.GetLeads
{
    public  class GetAcceptedLeadsQuery : IRequest<List<GetAcceptedLeadsViewModel>>
    {
    }
}
