using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infraestructure.Data;
using Core.Entitys;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlacesController : ControllerBase
    {
        //injection of de dbcontext to this controller
        private readonly AplicationDbContext _db;
       public PlacesController(AplicationDbContext db)
       {
           _db=db;
       }
        //never forguet make asynk the method get by this way!!
        [HttpGet]
        public async Task<ActionResult<List<Place>>> GetPlaces(){
            var Places= await _db.Places.ToListAsync();
            return Ok(Places);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<Place>> GetPlace(int id){
            var Place= await _db.Places.FindAsync(id);
            return Place;
        }
    }
}