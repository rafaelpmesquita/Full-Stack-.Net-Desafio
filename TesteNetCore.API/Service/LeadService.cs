using Azure.Core;
using MediatR;
using System.Data.Common;
using TesteNetCore.API.Service.Interface;
using TesteNetCore.Application.Mapper;
using TesteNetCore.Domain.Entities;
using TesteNetCore.Domain.Enum;
using TesteNetCore.Domain.Exceptions;
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
                        .Where(x => x.StatusLeadId == Domain.Enum.LeadStatus.Pending)
                        .ToList();
                return _objectConverter.Map<List<LeadIncompleteModel>>(pendingLeads);

            }
            catch (CustomLeadException ex)
            {
                Console.WriteLine($"Exception Title: {ex.Title}");
                Console.WriteLine($"Exception Custom Message: {ex.CustomMessage}");
                throw;
            }
        }
        public async Task<List<Lead>> GetAcceptedLeads()
        {
            try
            {
                List<Lead> pendingLeads = (await _leadRepository.GetLeads())
                        .Where(x => x.StatusLeadId == Domain.Enum.LeadStatus.Accepted)
                        .ToList();
                return pendingLeads;
            }
            catch (CustomLeadException ex)
            {
                Console.WriteLine($"Exception Title: {ex.Title}");
                Console.WriteLine($"Exception Custom Message: {ex.CustomMessage}");
                throw;
            }
        }

        public async Task<int> ChangeLeadStatus(LeadIncompleteModel request)
        {
            try
            {
                Lead? lead = (await _leadRepository.GetLeads())
                    .FirstOrDefault(x => x.Id == request.Id);
                if (lead == null)
                {
                    throw new CustomLeadException("Lead not found.","Lead do not exist.");
                }
                if (lead.StatusLeadId != LeadStatus.Pending)
                {
                    throw new CustomLeadException("No Pending Leads", "There are no leads with pending status.");
                }
                if (request.StatusLeadId == LeadStatus.Accepted)
                {
                    lead.Price = lead.Price > 500 ? lead.Price * (decimal)0.9 : lead.Price;

                    await SendNotificationEmail("vendas@test.com", lead);
                }
                lead.StatusLeadId = request.StatusLeadId;
                return await _leadRepository.UpdateLead(lead);
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
                emailContent += $"To: {emailAddress}\n";
                emailContent += $"Lead Accepted\n";

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
