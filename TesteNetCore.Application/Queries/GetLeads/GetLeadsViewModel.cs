using TesteNetCore.Domain.Enum;

namespace TesteNetCore.Application.Queries.GetLeads
{
    public class GetLeadsViewModel
    {
        public string ContactFirstName { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public string Suburb { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Id { get; set; }
        public LeadStatus StatusLeadId { get; set; }

    }
}
