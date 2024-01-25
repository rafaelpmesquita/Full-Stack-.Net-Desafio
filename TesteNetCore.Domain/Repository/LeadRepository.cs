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
    public class LeadRepository : BaseRepository<Lead>, ILeadRepository
    {
        public LeadRepository(DbContext context) : base(context)
        {
        }

        public async Task<int> UpdateLead(Lead lead)
        {
            return (await UpdateAsync(lead)).Id;
        }

        public async Task<List<Lead>> GetLeads()
        {
            var response = await GetQueryable().ToListAsync();
            return await Task.FromResult((response));

        }
    }
}
