using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Error
{
    public class ApiExceptions : ApiResponse
    {
        public ApiExceptions(int StatusCode, string Message = null, string Detail =null) : base(StatusCode, Message)
        {
            _Detail=Detail;
        }

        public string _Detail { get; set; }
    }
}