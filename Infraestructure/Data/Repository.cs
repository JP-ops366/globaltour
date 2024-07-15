using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especifications;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Infraestructure.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public AplicationDbContext _db;
        public Repository(AplicationDbContext db)
        {
            _db = db;

        }
        public async Task<T> GetAsync(int id)
        {
           return await _db.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
           return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetEspecification(IEspecifications<T> especifications)
        {
            return await ApplyEspecifications(especifications).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllEspecifications(IEspecifications<T> especifications)
        {
            return await ApplyEspecifications(especifications).ToListAsync();
        }

        private IQueryable<T> ApplyEspecifications(IEspecifications<T>especifications )
        {
           return EspecificationsEvaluer<T>.GetQuery(_db.Set<T>().AsQueryable(), especifications);
        }
    }

    
}