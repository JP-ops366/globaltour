using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Infraestructure.Data
{
    public class EspecificationsEvaluer<T> where T:class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> InputQuery, IEspecifications<T> especification)
        {
          var Query=InputQuery;
          if (especification.Filter!=null)
          {
            Query=Query.Where(especification.Filter);
            
          }
          Query=especification.Includes.Aggregate(Query,(current,include)=>current.Include(include));
          return Query;
        }
    }
}