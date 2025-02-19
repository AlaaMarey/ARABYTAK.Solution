using Arabytak.Core.Entities;
using Arabytak.Core.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Repository
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity // Some Funcs For return The query
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> innerQuery, ISpecification<TEntity> spec)//use IQueryable becouse do filter in DB then do return(Built query and return)
        {
            var query = innerQuery;// _DbContext.Set<Car>()=> الجزء ال بيمسك جدول ال في داتا بيز
            // if there is where condition
            if (spec.Criteria is not null)
            {
                query=query.Where(spec.Criteria);//_store.Set<Car>().Where(c=>c.Id==id)
            }
            if(spec.IsPaginationEnabled)
            {
                query=query.Skip(spec.Skip).Take(spec.Take);
            }
            query=spec.Includes.Aggregate(query,(CurrentQuery,includeEcpression)=>CurrentQuery.Include(includeEcpression));
            //CurrentQuery=>شايل ال query لحد اخر حاجه ضفتها
            return query;//query= _dbcontext.set<Car>().Where(c=>c.Id==id).Include(c=>c.Brand). .....

        }
    }
}
