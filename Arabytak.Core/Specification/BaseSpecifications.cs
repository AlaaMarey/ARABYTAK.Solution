using Arabytak.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Core.Specification
{
    public class BaseSpecifications<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get ; set; }//where(c=>c.Id==Id)
        public List<Expression<Func<T, object>>> Includes { get; set ; }= new List<Expression<Func<T, object>>>();
        //public Expression<Func<T, object>> OrderBy { get ; set ; }
        //public Expression<Func<T, object>> OrderByDesc { get ; set ; }
        public int Take { get ; set ; }
        public int Skip { get ; set ; }
        public bool IsPaginationEnabled { get ; set ; }
        public BaseSpecifications()//initialize 
        {
            //Criteria= Null
            //  Includes = new List<Expression<Func<T, object>>>();

        }
        public BaseSpecifications(Expression<Func<T,bool>> CriteriaExpression)
        {
            Criteria = CriteriaExpression;   
        }
        public void ApplyPagination(int skip , int take)
        {
            Take = take;
            Skip = skip;
            IsPaginationEnabled = true;
        }
    }
}
