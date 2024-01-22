using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNetCore.Domain.Entities;
using TesteNetCore.Domain.Enum;
using TesteNetCore.Domain.Repository.Base;
using TesteNetCore.Domain.Repository.Interface;

namespace TesteNetCore.Domain.Repository
{
    public class LeadRepository : BaseRepository<Leads>, ILeadRepository
    {
        public LeadRepository(DbContext context) : base(context)
        {
        }

        public async Task UpdateLead(Leads lead)
        {
            await UpdateAsync(lead);
        }

        public async Task<List<Leads>> GetLeads()
        {
            return await GetQueryable().ToListAsync();
             
        }
    }
}
