using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitys;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Data
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly AplicationDbContext _db;
        public PlaceRepository(AplicationDbContext db)
        {
            _db=db;
        }
        public async Task<Place> GetPlaceAsynk(int id)
        {
           return await _db.Places
                        .Include(l=>l.category)
                         .Include(c=>c.country)
                          .FirstOrDefaultAsync(p=>p.id==id);
        }

        public async Task<IReadOnlyList<Place>> GetPlacesAsynk()
        {
            return await _db.Places
                         .Include(l=>l.category)
                         .Include(c=>c.country)
                         .ToListAsync();
        }
    }
}