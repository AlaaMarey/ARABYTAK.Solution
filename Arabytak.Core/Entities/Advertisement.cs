using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Core.Entities
{
    public class Advertisement:BaseEntity
    {
            
            public string? Description { get; set; }    
            public DateTime StartCreateAdvertisement { get; set; } = DateTime.Now;
            public string SellerEmail { get; set; }    
            public string ContactInfo { get; set; }    
            public decimal Price { get; set; }         
       // public string PaymentMethod { get; set; }  // طريقة الدفع (بطاقة، تحويل بنكي...)
       // public string PaymentStatus { get; set; }  // حالة الدفع (Pending, Paid, Failed)
       // public string TransactionId { get; set; }  // رقم العملية للدفع (إن وجد)
        public DateTime ExpiryDate { get; set; }   // تاريخ انتهاء صلاحية الإعلان
        public int? AdPlanId { get; set; }//Fk[AdPlan]--Handle by FluentApi
        public AdPlan planForAdvertisement { get; set; }//NavProp [one]=>AdPlan
        public int? CarId { get; set; }
        public Car  Car { get; set; }//navProp[one]
    }
}
