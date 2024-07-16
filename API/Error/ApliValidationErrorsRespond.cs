using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Error
{
    public class ApliValidationErrorsRespond : ApiResponse
    {
        public ApliValidationErrorsRespond() : base(400,null)
        {
        }
        public IEnumerable<string> Errors{get; set;}
    }
}