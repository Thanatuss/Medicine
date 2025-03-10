using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Entities;

namespace Pharmecy.Infrastructure.Data.DbContext
{
    public class ProgramDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ProgramDbContext(DbContextOptions<ProgramDbContext> option) : base(option)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProgramDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Medicine> Medicine { get; set; }
    }
}
