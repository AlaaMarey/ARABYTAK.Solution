using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Core.Entities
{
        public class CarPictureUrl:BaseEntity
        {
            public string PictureUrl { get; set; }
        //public ICollection<Car> Cars { get; set; }=new HashSet<Car>();
        public Car car { get; set; }
        public int CarId { get; set; }
    }
}
