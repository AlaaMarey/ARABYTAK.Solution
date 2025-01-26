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
    internal class RescueCompaniesConfig : IEntityTypeConfiguration<RescueCompany>
    {
        public void Configure(EntityTypeBuilder<RescueCompany> builder)
        {
            builder.Property(c=>c.Id).ValueGeneratedNever();
        }
    }
}
