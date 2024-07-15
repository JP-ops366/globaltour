using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Especifications
{
    public class BaseEspecifications<T> : IEspecifications<T>
    {
        public Expression<Func<T, bool>> Filter {get;} 

        public List<Expression<Func<T, object>>> Includes {get;}=new List<Expression<Func<T, object>>>();
        
        public BaseEspecifications(Expression<Func<T,bool>> filter)
       {
          Filter=filter;
       } 

       protected void AddInclude(Expression<Func<T,object>> Includesexpression)
       {
         Includes.Add(Includesexpression);
       }

       public BaseEspecifications()
       {
        
       }
    }
}