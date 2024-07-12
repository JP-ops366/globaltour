using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entitys;

namespace Infraestructure.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Place> Places { get; set; }
    }
}