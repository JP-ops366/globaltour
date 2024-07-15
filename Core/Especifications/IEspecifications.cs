using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Especifications
{
    public interface  IEspecifications<T>
    {
        Expression<Func<T,bool>> Filter{get;}
        List<Expression<Func<T, object>>> Includes{get;}
    }
}