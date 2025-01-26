using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Core.Entities
{
    public class Brand:BaseEntity
    {
        public string Name { get; set; }
        //[InverseProperty("brand")]
        //  public ICollection<Car> Cars { get; set; }= new HashSet<Car>();
        public string? PictureUrl { get; set; }
    }
}
