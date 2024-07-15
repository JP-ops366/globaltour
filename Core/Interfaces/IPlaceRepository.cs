using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitys;

namespace Core.Interfaces
{
    public interface IPlaceRepository
    {
        Task<Place> GetPlaceAsynk(int id);
        Task<IReadOnlyList<Place>> GetPlacesAsynk();
    }
}