using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entitys;
using Microsoft.Extensions.Logging;

namespace Infraestructure.Data
{
    public class DataBaseSeed
    {
        public static async Task SeedAsync(AplicationDbContext context, ILoggerFactory loggerFactory)
        {
           try
           {
                if(!context.Countries.Any()){
                var dataCountry= File.ReadAllText("../Infraestructure/Data/SeedData/country.json");
                var Countries = JsonSerializer.Deserialize<List<Country>>(dataCountry);
                foreach (var item in Countries)
                {
                    await context.Countries.AddAsync(item);
                }
               await context.SaveChangesAsync();
               
               }
              
                if (!context.Categories.Any())
                {
                    var DataCategory =File.ReadAllText("../Infraestructure/Data/SeedData/categories.json");
                    var categories = JsonSerializer.Deserialize<List<Category>>(DataCategory);
                    foreach (var item in categories)
                    {
                       await context.Categories.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }

                 if (!context.Places.Any())
                {
                    var DataPlace = File.ReadAllText("../Infraestructure/Data/SeedData/lugares.json");
                    var places = JsonSerializer.Deserialize<List<Place>>(DataPlace);
                    foreach (var item in places)
                    {
                      await context.Places.AddAsync(item); 
                    }
                    await context.SaveChangesAsync();
                }
           }
           catch (System.Exception ex) 
           {
             
             var logger = loggerFactory.CreateLogger<DataBaseSeed>();
             logger.LogError(ex,"Error seed");
           }
        }
    }
}