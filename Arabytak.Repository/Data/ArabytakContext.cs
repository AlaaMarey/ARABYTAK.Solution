using Arabytak.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Repository.Data
{
    public class ArabytakContext:DbContext
    {
        public ArabytakContext(DbContextOptions<ArabytakContext> option):base(option)//first step to create connection with Db
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> models { get; set; }
        public DbSet<Car> cars { get; set; }
        public DbSet<CarPictureUrl> carsPictureUrls { get; set; }
        public DbSet<Advertisement> advertisements { get; set; }
        public DbSet<Dealership> deals { get; set; }
        public DbSet<SpecNewCar> specNewCars { get; set; }
        public DbSet<SpecUsedCar> specUsedCars { get; set; }
        public DbSet<AdPlan> adplan { get; set; }
        public DbSet<InsuranceCompany> insuranceCompanys { get;set; }
        public DbSet<MaintenanceCenter> maintenanceCenter { get; set; }
        public DbSet<RescueCompany> rescueCompanys { get;set;}

            
    }
}
