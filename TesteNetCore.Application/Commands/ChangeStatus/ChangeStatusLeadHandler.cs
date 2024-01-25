using AutoMapper;
using MediatR;
using TesteNetCore.Application.Mapper;
using TesteNetCore.Application.Queries.GetLeads;
using TesteNetCore.Domain.Entities;
using TesteNetCore.Domain.Enum;
using TesteNetCore.Domain.Exceptions;
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
                    throw new CustomLeadException("Lead not found.", "Lead do not exist.");
                }
                if (lead.StatusLeadId != LeadStatus.Pending)
                {
                    throw new CustomLeadException("No Pending Leads", "There are no leads with pending status.");
                }
                if (request.StatusLeadId == LeadStatus.Accepted)
                {
                    lead.Price = lead.Price > 500 ? lead.Price * (decimal)0.9 : 500;

                    await SendNotificationEmail("vendas@test.com", lead);

                }
                lead.StatusLeadId = request.StatusLeadId;
                await _leadRepository.UpdateLead(lead);
                return await Task.FromResult(Unit.Value);
            }
            catch (CustomLeadException ex)
            {
                Console.WriteLine($"Exception Title: {ex.Title}");
                Console.WriteLine($"Exception Custom Message: {ex.CustomMessage}");
                throw;
            }
        }


        private async Task SendNotificationEmail(string emailAddress, Lead lead)
        {
            try
            {
                string emailContent = $"Subject: New Lead Accepted\n\n";
                emailContent += $"Lead ID: {lead.Id}\n";
                emailContent += $"Contact: {lead.ContactFullName}\n";
                emailContent += $"Suburb: {lead.Suburb}\n";
                emailContent += $"Category: {lead.Category}\n";
                emailContent += $"Description: {lead.Description}\n";
                emailContent += $"Price: {lead.Price:C}\n";
                emailContent += $"Contact Email: {lead.ContactEmail}\n";

                string fileName = $"LeadNotification_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                File.WriteAllText(filePath, emailContent);

                Console.WriteLine($"Notification email saved to file: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving notification email to file: {ex.Message}");
            }
        }

    }
}
