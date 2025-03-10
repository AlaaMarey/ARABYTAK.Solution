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
 //       public CarWithBrandAndCategoryAndPicUrlAndSpecSpecification(CarSpecParams spec):    base(p=>
 //(string.IsNullOrEmpty(spec.Search) ||
 //            (p.brand != null && p.brand.Name.ToLower().Contains(spec.Search.ToLower())) ||  // البحث في العلامة التجارية
 //            (p.model != null && p.model.Name.ToLower().Contains(spec.Search.ToLower()))) 
  

 //       )
 //       {
 //           Includes.Add(p => p.brand);
 //           Includes.Add(p => p.model);
 //           Includes.Add(d => d.dealership);
           
 //           if (spec.Status==Status.New)
 //           {
 //               Includes.Add(p => p.specNewCar);
 //           }
 //           else if(spec.Status==Status.Used)
 //           {
 //               Includes.Add(p=>p.specUsedCar);
 //           }

            
        //    Includes.Add(p => p.Url);
        //    ApplyPagination((spec.PageIndex - 1) * spec.PageSize, spec.PageSize);// total car =20, pagesize=5,pageindex=2 =>apply(2-1)*5 ,5 ==>skip5, take 5

        //}
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
        public CarWithBrandAndCategoryAndPicUrlAndSpecSpecification(Status status): base(c=>c.status==status) 
        {
            Includes.Add(p => p.brand);
            Includes.Add(m => m.model);
            Includes.Add(d => d.dealership);
            Includes.Add(p => p.Url);
        }
        public CarWithBrandAndCategoryAndPicUrlAndSpecSpecification(int id) : base(c => c.Id==id)
        {
            Includes.Add(p => p.brand);
            Includes.Add(m => m.model);
            Includes.Add(d => d.dealership);
            Includes.Add(p => p.Url);
        }
    }
}
