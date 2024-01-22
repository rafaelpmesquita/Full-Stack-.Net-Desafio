using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNetCore.Domain.Entities;

namespace TesteNetCore.Domain.Repository.Interface
{
    public interface ILeadRepository
    {
        Task<List<Leads>> GetLeads();
        Task UpdateLead(Leads lead);
    }
}
