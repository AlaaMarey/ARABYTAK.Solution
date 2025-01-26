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
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.HasOne(c => c.dealership).WithMany().HasForeignKey(f => f.DealershipId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(c=>c.brand).WithMany().HasForeignKey(f=>f.BrandId) .OnDelete(DeleteBehavior.SetNull);
           // builder.HasOne(c=>c.specification).WithOne().HasForeignKey<Car>(f=>f.specificationId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.specNewCar).WithOne().HasForeignKey<Car>(f => f.SpecNewCarId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.specUsedCar).WithOne().HasForeignKey<Car>(f => f.SpecUsedCarId).OnDelete(DeleteBehavior.Cascade);
           // builder.HasOne(c=>c.Url).WithMany().HasForeignKey(f=>f.CarPictureUrlId).OnDelete(DeleteBehavior.Cascade);
           // builder.HasOne(c => c.category).WithMany().HasForeignKey(f => f.CategoryId);
            builder.HasOne(c => c.model    ).WithMany().HasForeignKey(f => f.ModelId);
           // builder.Property(c => c.Name).IsRequired().HasMaxLength(150);
            builder.Property(c=>c.Price).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(C=>C.status)
                .HasConversion(
                car => car.ToString(),
                car => (Status)Enum.Parse(typeof(Status), car));
            builder.Property(c=>c.condition)
                .HasConversion(
                car=>car.ToString(),
                car=> (Condition)Enum.Parse(typeof(Condition), car));
        }
    }
}
