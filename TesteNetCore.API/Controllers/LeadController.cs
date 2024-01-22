using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteNetCore.Application.Commands.ChangeStatus;
using TesteNetCore.Application.Queries.GetLeads;
using TesteNetCore.Domain.Entities;

namespace TesteNetCore.API.Controllers
{
    [Route("/api/[controller]")]
    public class LeadController : Controller
    {
        private readonly IMediator _mediator;
        public LeadController(IMediator mediator) {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetLeads()
        {
            var getLeads = new GetLeadsQuery();
            var result = await _mediator.Send(getLeads);
            return Ok(result);
        }
        [HttpGet("accepted")]
        public async Task<IActionResult> GetAcceptedLeads()
        {
            var getLeads = new GetAcceptedLeadsQuery();
            var result = await _mediator.Send(getLeads);
            return Ok(result);
        }

        [HttpPut("changeStatus")]
        public async Task<IActionResult> ToAcceptedLead([FromBody] ChangeStatusLeadCommand lead)
        {
            var result = await _mediator.Send(lead);
            return Ok(result);
        }
    }
}
 