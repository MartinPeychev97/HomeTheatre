using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.HttpExeptionHandlers
{
    public class GeneralExeptionHandler
    {
        private readonly RequestDelegate _rd;

        public GeneralExeptionHandler(RequestDelegate rd)
        {
            _rd = rd;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _rd.Invoke(context);
            }
            catch (Exception)
            {
                if (context.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("Something went wrong");
                }
                else
                {
                    context.Response.Redirect("error/generalerror");
                }
            }
        }
    }
    
    public static class GeneralExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseGeneralExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GeneralExeptionHandler>();
        }
    }
}
