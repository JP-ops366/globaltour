using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especifications;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : class 
    {
     Task<T> GetAsync(int id);
     Task<IReadOnlyList<T>> GetAllAsync();
     Task<T> GetEspecification(IEspecifications<T>especifications);
     Task<IReadOnlyList<T>> GetAllEspecifications(IEspecifications<T>especifications);
    }
}