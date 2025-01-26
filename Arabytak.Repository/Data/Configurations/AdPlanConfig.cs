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
    public class AdPlanConfig : IEntityTypeConfiguration<AdPlan>
    {
        public void Configure(EntityTypeBuilder<AdPlan> builder)
        {
            builder.Property(Ad => Ad.planType)
                .HasConversion(
                AdPlanType => AdPlanType.ToString(),
                AdPlanType => (PlanType)Enum.Parse(typeof(PlanType), AdPlanType));
            builder.Property(Ad => Ad.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
