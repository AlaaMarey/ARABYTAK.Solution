using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Core.Entities
{
    public class Model:BaseEntity
    {
        public string Name { get; set; }
       // [InverseProperty("model")]
      //  public ICollection<Car> Cars { get; set; }= new HashSet<Car>();
    }
}
