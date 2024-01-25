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
        public LeadController(IMediator mediator, ILeadService leadService)
        {
            _mediator = mediator;
            _leadService = leadService;
        }

        #region CQRS ENDPOINTS
        [HttpGet("cqrs")]
        public async Task<IActionResult> GetLeads()
        {
            GetLeadsQuery getLeads = new GetLeadsQuery();
            return Ok(await _mediator.Send(getLeads));
        }
        [HttpGet("cqrs/accepted")]
        public async Task<IActionResult> GetAcceptedLeads()
        {
            GetAcceptedLeadsQuery getLeads = new GetAcceptedLeadsQuery();
            return Ok(await _mediator.Send(getLeads));
        }

        [HttpPut("cqrs/changeStatus")]
        public async Task<IActionResult> ToAcceptLead([FromBody] ChangeStatusLeadCommand lead)
        {
            return Ok(await _mediator.Send(lead));
        }
        #endregion



        #region ENDPOINTS CONTROLLER, SERVICE, REPOSITORY = CSR
        [HttpGet]
        public async Task<IActionResult> GetPendingLeadsCSR()
        {
            return Ok(await _leadService.GetPendingLeads());
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
