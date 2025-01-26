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
    public class SpecUsedCarConfig : IEntityTypeConfiguration<SpecUsedCar>
    {
        public void Configure(EntityTypeBuilder<SpecUsedCar> builder)
        {
            builder.Property(s=>s.Mileage)
                .HasColumnType("decimal(18,2)");
        }
    }
}
