using Arabytak.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Repository.Data.Configurations
{
    public class SpecNewCarConfig : IEntityTypeConfiguration<SpecNewCar>
    {
        public void Configure(EntityTypeBuilder<SpecNewCar> builder)
        {
            builder.Property(s => s.FuelEfficiency)
                .HasColumnType("decimal(18,2)");
            builder.Property(s=>s.Acceleration)
                .HasColumnType("decimal(18,2)");
            builder.Property(s=>s.Length)
                .HasColumnType("decimal(18,2)");
            builder.Property(s=>s.Width)
                .HasColumnType("decimal(18,2)");
            builder.Property(s=>s.Height)
                .HasColumnType("decimal(18,2)");
            builder.Property(s=>s.GroundClearance)
                .HasColumnType("decimal(18,2)");
            builder.Property(s=>s.Wheelbase)
                .HasColumnType("decimal(18,2)");
            builder.Property(s=>s.TrunkSize)
                   .HasColumnType("decimal(18,2)");
        }
    }
}
