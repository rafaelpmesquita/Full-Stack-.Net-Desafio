using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNetCore.Domain.Enum;

namespace TesteNetCore.Application.Commands.ChangeStatus
{
    public class ChangeStatusLeadModel
    {
        public string ContactFirstName { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public string Suburb { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public LeadStatus Status { get; set; }

    }
}
