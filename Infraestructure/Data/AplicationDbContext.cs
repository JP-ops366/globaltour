
using Microsoft.EntityFrameworkCore;
using Core.Entitys;
using System.Reflection;

namespace Infraestructure.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Place> Places { get; set; }
        public DbSet<Country> Countries{get; set;}
        public DbSet<Category> Categories{get;set;}

     //this method create migrations and its here where we must pass the config of Data/Config/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}