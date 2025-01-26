using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Core.Entities
{
    public class RescueCompany:BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }

   
        public int Phone1 { get; set; } 
        public int? Phone2 { get; set; }     
        public int? Phone3 { get; set; } 

   
        public string Service1 { get; set; }             
        public string? Service2 { get; set; }
        public string? Service3 { get; set; } 
        public string? Service4 { get; set; } 
    }
}
