using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Core.Entities
{
    public enum PlanType
    {
        [EnumMember(Value = "Weekly")]
        Weekly,
        

        [EnumMember(Value = "Monthly")]  
        Monthly,

        [EnumMember(Value = "Yearly")]   
        Yearly
    }
    public class AdPlan:BaseEntity
    {
        public PlanType planType { get; set; }
        public decimal Price { get; set; }
        //public string PlanName { get; set; }        // اسم الخطة (مثل أسبوعي، شهري)
        //  public int DurationInDays { get; set; }     // مدة الخطة بالأيام

        // public ICollection<Advertisement> advertisements { get; set; } = new HashSet<Advertisement>();//NavProp[Many]=>Each plan have Many Advertisement--dont need this but Handle by FluentApi
        // use this prop when i need to deliver to what this plan use in Any Advertisement ex: have plan i need to what advertisement use this plan
    }
}
