using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Infrastructure.EF.Models;

namespace TravelManagement.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<TravelerCheckListReadModel>, IEntityTypeConfiguration<TravelerItemReadModel>
    {
        public void Configure(EntityTypeBuilder<TravelerItemReadModel> builder)
        {
            builder.ToTable("TravelerItems");
        }

        public void Configure(EntityTypeBuilder<TravelerCheckListReadModel> builder)
        {
            builder.ToTable("TravelerCheckList");
            builder.HasKey(pl => pl.Id);

            builder
                .Property(pl => pl.Destination)
                .HasConversion(l => l.ToString(), l => DestinationReadModel.Create(l));

            builder
                .HasMany(pl => pl.Items)
                .WithOne(pi => pi.TravelerCheckList);
        }
    }
}
