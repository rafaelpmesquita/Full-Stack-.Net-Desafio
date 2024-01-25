using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TesteNetCore.Domain.Enum;

namespace TesteNetCore.Application.Commands.ChangeStatus
{
    public class ChangeStatusLeadCommand : IRequest<Unit>
    {
        public ChangeStatusLeadCommand(string contactFirstName, DateTime dateCreated, string suburb, string category, string description, double price, int id)
        {
            ContactFirstName = contactFirstName;
            DateCreated = dateCreated;
            Suburb = suburb;
            Category = category;
            Description = description;
            Price = price;
            Id = id;
        }

        public string ContactFirstName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }
        public LeadStatus StatusLeadId { get; set; }

    }
}
