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

        public async Task UpdateLead(Lead lead)
        {
            await UpdateAsync(lead);
        }

        public async Task<List<Lead>> GetLeads()
        {
            var a=  GetQueryable();
            return await Task.FromResult(a.ToList());
             
        }
    }
}
