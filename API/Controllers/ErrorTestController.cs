using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Infraestructure.Data;
using Core.Entitys;
using System.Data.Common;
using API.Error;

namespace API.Controllers
{
   [Route("api/[controller]")]
    public class ErrorTestController : Controller
    {
       

        private readonly AplicationDbContext _db;
        public ErrorTestController(AplicationDbContext db)
        {
         _db=db;
        
        }

        [HttpGet ("NotFound")]
        public ActionResult GetNotFound(){
            var something = _db.Places.Find(166);
            if (something==null)
            { 
                return  NotFound(new ApiResponse(404,null));
            }
            return Ok();
        }
          [HttpGet ("ServerError")]
        public ActionResult GetServerError(){
             var something = _db.Places.Find(166);
             var s1omething=something.ToString();
             return Ok();
        }

         [HttpGet ("BadRequest/{id}")]
        public ActionResult GetBadRecuestError(int id){
            return BadRequest( );
        }
       
    }
}