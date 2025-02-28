using Arabytak.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Core.Specification.AdvertisementSpec
{
    public class AdvWithTablesSpec:BaseSpecifications<Advertisement>
    {
        public AdvWithTablesSpec(int AdvId):base(c=>c.Id==AdvId)
        {
            Includes.Add(p => p.Car);
            Includes.Add(p=>p.Car.brand);
            Includes.Add(p=>p.Car.model);
            Includes.Add(p=>p.planForAdvertisement);
            Includes.Add(p => p.Car.Url);
            Includes.Add(p => p.Car.specUsedCar);
            
            
        }
        public AdvWithTablesSpec()
        {
            Includes.Add(p => p.Car);
            Includes.Add(p => p.Car.brand);
            Includes.Add(p => p.Car.model);
            Includes.Add(p => p.Car.Url);
        }
    }
}
