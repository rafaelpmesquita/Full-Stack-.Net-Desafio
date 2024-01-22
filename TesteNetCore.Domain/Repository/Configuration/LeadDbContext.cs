using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNetCore.Domain.Entities;
using TesteNetCore.Domain.Enum;

namespace TesteNetCore.Domain.Repository.Configuration
{
    public class LeadDbContext : DbContext
    {
        public LeadDbContext(DbContextOptions<LeadDbContext> options) : base(options)
        {
        }

        public DbSet<Leads> Leads { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leads>()
                .Property(e => e.StatusLeadId)
                .HasConversion<int>();
        }
    }
}
