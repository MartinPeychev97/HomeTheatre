using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.HttpExeptionHandlers
{
    public class PageNotFoundHandler
    {
        private readonly RequestDelegate _rd;

        public PageNotFoundHandler(RequestDelegate rd)
        {
            _rd = rd;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            await _rd.Invoke(httpContext);

            if (httpContext.Response.StatusCode == 404)
            {
                httpContext.Response.Redirect("/Home/PageNotFound");
            }
        }
    }
}
