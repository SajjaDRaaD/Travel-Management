using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Infrastructure.EF.Config;
using TravelManagement.Infrastructure.EF.Models;

namespace TravelManagement.Infrastructure.EF.Contexts
{
    public sealed class WriteDbContext : DbContext
    {
        public DbSet<TravelerCheckList> TravelerCheckLists { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TravelerCheckList");

            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<TravelerCheckList>(configuration);
            modelBuilder.ApplyConfiguration<TravelerItem>(configuration);
        }
    }
}
