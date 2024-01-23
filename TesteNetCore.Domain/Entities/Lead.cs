using System.ComponentModel.DataAnnotations;
using TesteNetCore.Domain.Enum;

namespace TesteNetCore.Domain.Entities
{
    public class Lead
    {
        public Lead() { }
        public Lead(string contactFirstName, DateTime dateCreated, string suburb, string category, string description, decimal price, string contactFullName, string contactPhoneNumber, string contactEmail, LeadStatus statusLeadId)
        {
            ContactFirstName = contactFirstName;
            DateCreated = dateCreated;
            Suburb = suburb;
            Category = category;
            Description = description;
            Price = price;
            ContactFullName = contactFullName;
            ContactPhoneNumber = contactPhoneNumber;
            ContactEmail = contactEmail;
            StatusLeadId = statusLeadId;
        }
        
        public string ContactFullName { get; set; } 
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public int Id { get; set; }
        public string ContactFirstName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public LeadStatus StatusLeadId { get; set; }
    }
}
