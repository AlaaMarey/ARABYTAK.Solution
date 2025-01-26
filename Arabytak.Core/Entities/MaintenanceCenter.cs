using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Core.Entities
{
    public class MaintenanceCenter:BaseEntity
    {
        public string Name {  get; set; }
        public string AvailableServices { get; set; }
    }
}
