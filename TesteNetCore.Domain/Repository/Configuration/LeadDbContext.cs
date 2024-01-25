using Microsoft.EntityFrameworkCore;
using TesteNetCore.Domain.Entities;

namespace TesteNetCore.Domain.Repository.Configuration
{
    public class LeadDbContext : DbContext
    {
        public LeadDbContext(DbContextOptions<LeadDbContext> options) : base(options)
        {
        }

        public DbSet<Lead> Leads { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lead>()
                .Property(e => e.StatusLeadId)
                .HasConversion<int>();

        }
    }
}
