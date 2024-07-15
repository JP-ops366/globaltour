using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entitys;

namespace Core.Especifications
{
    public class LugaresConPaisCAtegoriasEspecificacion : BaseEspecifications<Place>
    {
        public LugaresConPaisCAtegoriasEspecificacion()
        {
            AddInclude(x=>x.country);
            AddInclude(x=>x.category);
        }

        public LugaresConPaisCAtegoriasEspecificacion(int id) : base(x=>x.id==id)
        {
            AddInclude(x=>x.country);
            AddInclude(x=>x.category);
        }
    }
}