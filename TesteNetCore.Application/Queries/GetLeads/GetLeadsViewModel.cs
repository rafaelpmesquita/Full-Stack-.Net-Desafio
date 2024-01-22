using TesteNetCore.Domain.Enum;

namespace TesteNetCore.Application.Queries.GetLeads
{
    public class GetLeadsViewModel
    {
        public string ContactFirstName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Id { get; set; }
        public LeadStatus StatusLeadId { get; set; }

    }
}
