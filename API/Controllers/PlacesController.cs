using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infraestructure.Data;
using Core.Entitys;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Especifications;
using AutoMapper;
using API.DTOs;
using API.Error;
using Microsoft.OpenApi.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlacesController : ControllerBase
    {
        //injection of the Iplacerepository to this controller
        public readonly IRepository<Place> _IPR;
        private readonly IRepository<Country> _ICR;
        private readonly IRepository<Category> _ICaR;

        private readonly IMapper _mapper;
       public PlacesController(IRepository<Place> IPR, IRepository<Country> ICR, IRepository<Category> ICaR, IMapper mapper)
       {
            _mapper=mapper;
            _ICaR = ICaR;
            _ICR = ICR;
            _IPR = IPR;
          
       }
        //never forguet make asynk the method get by this way!!
        [HttpGet]
        public async Task<ActionResult<List<Place>>> GetPlaces(){
            var especification =new LugaresConPaisCAtegoriasEspecificacion();
            var Places= await _IPR.GetAllEspecifications(especification);
            return Ok(Places);
           
        }

        [HttpGet ("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Place>> GetPlace(int id){
            var especification = new LugaresConPaisCAtegoriasEspecificacion(id);
            var Place= await _IPR.GetEspecification(especification);

             if (Place==null) return NotFound(new ApiResponse(404,null));

            return Place;
        }

       
        [HttpGet("map/{id}")]
        public async Task<ActionResult<PlaceDTO>> GetPlaceMap(int id)
        {
             var especification = new LugaresConPaisCAtegoriasEspecificacion(id);
             var Place= await _IPR.GetEspecification(especification); 
             return  _mapper.Map<Place,PlaceDTO>(Place);
        }

         [HttpGet("map/")]
        public async Task<ActionResult<IReadOnlyList<PlaceDTO>>> GetPlacesMap(){
            var especification =new LugaresConPaisCAtegoriasEspecificacion();
            var Places= await _IPR.GetAllEspecifications(especification);
            return Ok(_mapper.Map<IReadOnlyList<Place>,IReadOnlyList<PlaceDTO>>(Places));
           
        }
        

        [HttpGet ("categories")]
        public async Task<ActionResult<List<Category>>> GetCategories(){
            return Ok(await _ICaR.GetAllAsync());
        }
        [HttpGet("counties")]
        public async Task<ActionResult<List<Country>>> GetCountries(){
            return Ok(await _ICR.GetAllAsync());
        }

        
    }
}