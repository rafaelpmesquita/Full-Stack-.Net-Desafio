using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNetCore.Domain.Enum;

namespace TesteNetCore.Domain.Entities
{   
    public class LeadIncompleteModel
    {
        [Key]
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
