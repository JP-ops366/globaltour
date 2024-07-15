using System.Linq.Expressions;
using API.Helpers;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Code that i made for DB connection is the same for every project
var connectionString= builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AplicationDbContext>(options=>
options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region servicios
//codo meda by me adding the repositories
builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();

builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

builder.Services.AddAutoMapper(typeof(MappingProfiles));
#endregion

var app = builder.Build();

//apply new migrations after run API (just update data base entities)
#region use it to automigrate with the "try" and show error message with the "catch"
using(var scope= app.Services.CreateScope()){
    var services = scope.ServiceProvider;
    var loggerFactory= services.GetRequiredService<ILoggerFactory>();
    try{
        var context = services.GetRequiredService<AplicationDbContext>();
        await context.Database.MigrateAsync();

        //this line provides us of an initial information for the DB
        await DataBaseSeed.SeedAsync(context, loggerFactory);
    }
    catch(System.Exception ex){var logger= loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "Error in migration");}
}
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseRouting();

app.UseHttpsRedirection();

//add this line for use the images in wwwroot
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
