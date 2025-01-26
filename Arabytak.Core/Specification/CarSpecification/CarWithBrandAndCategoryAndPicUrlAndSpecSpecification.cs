using Arabytak.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Core.Specification.CarSpecification
{
    public class CarWithBrandAndCategoryAndPicUrlAndSpecSpecification:BaseSpecifications<Car>
    {
       
        public CarWithBrandAndCategoryAndPicUrlAndSpecSpecification(int CarId,Status Status):base(c=>c.Id==CarId && c.status==Status)
        {
            Includes.Add(p => p.brand);
            Includes.Add(m=>m.model);
            Includes.Add(d=>d.dealership);
         
            if(Status==Status.New)
            {
                Includes.Add(p => p.specNewCar);
            }
            else if(Status==Status.Used)
            {
                Includes.Add(p=>p.specUsedCar);
            }
            Includes.Add(p => p.Url);
            
        }
    }
}
