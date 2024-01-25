using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteNetCore.API.Service.Interface;
using TesteNetCore.Application.Commands.ChangeStatus;
using TesteNetCore.Application.Queries.GetLeads;
using TesteNetCore.Domain.Entities;

namespace TesteNetCore.API.Controllers
{
    [Route("/api/[controller]")]
    public class LeadController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILeadService _leadService;
        public LeadController(IMediator mediator, ILeadService leadService) {
            _mediator = mediator;
            _leadService = leadService;
        }

        #region CQRS ENDPOINTS
        [HttpGet("cqrs")]
        public async Task<IActionResult> GetLeads()
        {
            var getLeads = new GetLeadsQuery();
            var result = await _mediator.Send(getLeads);
            return Ok(result);
        }
        [HttpGet("cqrs/accepted")]
        public async Task<IActionResult> GetAcceptedLeads()
        {
            var getLeads = new GetAcceptedLeadsQuery();
            var result = await _mediator.Send(getLeads);
            return Ok(result);
        }

        [HttpPut("cqrs/changeStatus")]
        public async Task<IActionResult> ToAcceptLead([FromBody] ChangeStatusLeadCommand lead)
        {
            var result = await _mediator.Send(lead);
            return Ok(result);
        }
        #endregion



        #region ENDPOINTS CONTROLLER, SERVICE, REPOSITORY = CSR
        [HttpGet]
        public async Task<IActionResult> GetPendingLeadsCSR()
        {
            var a = await _leadService.GetPendingLeads();
            return Ok(a);
        }

        [HttpGet("accepted")]
        public async Task<IActionResult> GetAcceptedLeadsCSR()
        {
            return Ok(await _leadService.GetAcceptedLeads());
        }
         
        [HttpPut("changeStatus")]
        public async Task<IActionResult> ToAcceptLeadCSR([FromBody] LeadIncompleteModel lead)
        {
            return Ok(await _leadService.ChangeLeadStatus(lead));
        }

        #endregion
    }
}
 