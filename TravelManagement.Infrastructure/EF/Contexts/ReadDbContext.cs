using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Infrastructure.EF.Config;
using TravelManagement.Infrastructure.EF.Models;

namespace TravelManagement.Infrastructure.EF.Contexts
{
    public class ReadDbContext : DbContext
    {
        public DbSet<TravelerCheckListReadModel> TravelerCheckLists { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TravelerCheckList");

            var configuration = new ReadConfiguration();
            modelBuilder.ApplyConfiguration<TravelerCheckListReadModel>(configuration);
            modelBuilder.ApplyConfiguration<TravelerItemReadModel>(configuration);
        }

    }
}
