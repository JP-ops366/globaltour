using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Error
{
    public class ApiResponse
    {
        public int _StatusCode { get; set; }
        public string _Message { get; set; }

        public ApiResponse(int StatusCode, string Message)
        {
            _StatusCode=StatusCode;
            _Message=Message ?? MessageStautsCode(StatusCode);
        }
        
        private string MessageStautsCode(int StatusCode)
        {
           return StatusCode switch 
           {
             400=> "Bad request has made",
             401=>  "No autorized",
             404=>  "Source has not found",
             500=> "Internal Server Error",
             _=>null
           };
        }

        
    }
}