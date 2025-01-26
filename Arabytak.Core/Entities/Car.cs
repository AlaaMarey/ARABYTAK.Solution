using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Core.Entities
{
    public enum Status
    {
        [EnumMember(Value = "New")]
        New,


        [EnumMember(Value = "Used")]
        Used
    }
    public enum Condition
    {
        [EnumMember(Value = "Available")]
        Available,


        [EnumMember(Value = "Sold")]
        Sold
    }
    public class Car:BaseEntity
    {
        //public string Name { get; set; }
        public Status status { get; set; }
        public decimal Price { get; set; }
        public Condition condition { get; set; }

        // public Advertisement  Advertisement { get; set; }//NavProp[One]
        public int? DealershipId {  get; set; }//fk

        public Dealership  dealership { get; set; }//NavProp[one]
        public int? BrandId { get; set; }//fk
        public Brand  brand { get; set; }//NavProp[one]
        //public int specificationId { get; set; }
        //public Specification  specification { get; set; }//NavProp[one]
        //public int? CategoryId { get; set; }
        //public Category  category { get; set; }
        public int? ModelId { get; set; }
      //  [InverseProperty("Cars")]
        public Model  model { get; set; }
        public int? SpecNewCarId { get; set; }
        public SpecNewCar  specNewCar { get; set; }
        public int? SpecUsedCarId { get; set; }
        public SpecUsedCar specUsedCar { get; set; }
        //public int? CarPictureUrlId { get; set; }
       // public CarPictureUrl? Url { get; set; }
        public ICollection<CarPictureUrl> Url { get; set; } = new HashSet<CarPictureUrl>();
    }
}
