using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Core.Entities
{
    public class Dealership:BaseEntity
    {
        public string Name { get; set; }
   
        public int? Phone1 { get; set; }
        public int? Phone2 { get; set; }
        public int? Phone3 { get; set; }
        public int? WhatsApp1 { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Branch1 { get; set; }
        public string? Branch2 { get; set; }
        public string? Branch3 { get; set; }
        // [InverseProperty("dealership")]
        //  public ICollection<Car> cars { get; set; } = new HashSet<Car>();//NavProp[Many]
    }
}
