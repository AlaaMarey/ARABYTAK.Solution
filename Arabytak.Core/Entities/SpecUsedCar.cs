using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Core.Entities
{
    public class SpecUsedCar:BaseEntity
    {
        public string City { get; set; }
       // public int PreviousOwners { get; set; }
       // public string ServiceHistory { get; set; }
        public string FuelType { get; set; }
       // public int HorsePower { get; set; }
        public string Transmission { get; set; }
        //public string Engine { get; set; }
        public string Color { get; set; }
        public int ManufacturingYear { get; set; }
        public string? Description { get; set; }
        public decimal Mileage { get; set; }
    }
}
