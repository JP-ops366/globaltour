using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infraestructure.Data;
using Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlacesController : ControllerBase
    {
        //injection of the Iplacerepository to this controller
        public readonly IPlaceRepository _IPR;
       public PlacesController(IPlaceRepository IPR)
       {
            _IPR = IPR;
          
       }
        //never forguet make asynk the method get by this way!!
        [HttpGet]
        public async Task<ActionResult<List<Place>>> GetPlaces(){
            var Places= await _IPR.GetPlacesAsynk();
            return Ok(Places);
           
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<Place>> GetPlace(int id){
            var Place= await _IPR.GetPlaceAsynk(id);
            return Place;
        }
    }
}