using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Error;

namespace API.MiddleWare
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleWare(RequestDelegate next, ILogger<ExceptionMiddleWare> logger,IHostEnvironment env )
        {
            _next=next;
            _logger=logger;
            _env=env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
           try{await _next(context);}
           catch(Exception ex)
           {
            _logger.LogError(ex,ex.Message);
            context.Response.ContentType="application/json";
            context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;

            var Response=_env.IsDevelopment() 
            ? new ApiExceptions((int)HttpStatusCode.InternalServerError, ex.Message,ex.StackTrace.ToString())
            : new ApiExceptions((int)HttpStatusCode.InternalServerError);
            var options=new JsonSerializerOptions{PropertyNamingPolicy=JsonNamingPolicy.CamelCase};
            var json =JsonSerializer.Serialize(Response,options);
            await context.Response.WriteAsync(json);
           }
        }
    }
}