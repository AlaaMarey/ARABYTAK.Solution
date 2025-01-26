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
    public class AdvertismentConfig : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.HasOne(A => A.planForAdvertisement).WithMany().HasForeignKey(A => A.AdPlanId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(C=>C.Car).WithOne().HasForeignKey<Advertisement>(A=>A.CarId).OnDelete(DeleteBehavior.SetNull);
            builder.Property(A => A.Description)
                .HasMaxLength(1000)
                .IsRequired(false);
            builder.Property(A => A.SellerEmail)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(A=>A.ContactInfo)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(A => A.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(A => A.StartCreateAdvertisement)
                .IsRequired();
            builder.Property(A => A.ExpiryDate)
                .IsRequired();
        }
    }
}
