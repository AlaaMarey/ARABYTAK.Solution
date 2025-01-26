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
    public  class DealershipConfig : IEntityTypeConfiguration<Dealership>
    {
        public void Configure(EntityTypeBuilder<Dealership> builder)
        {
            builder.Property(c=>c.Id).ValueGeneratedNever();
        }
    }
}
