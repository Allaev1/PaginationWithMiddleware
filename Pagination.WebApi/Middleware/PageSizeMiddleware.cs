using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.WebApi.Middleware
{
    public class PageSizeMiddleware 
    {
        RequestDelegate next;
        ILogger<PageSizeMiddleware> logger;

        public PageSizeMiddleware(RequestDelegate next, ILogger<PageSizeMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var a = httpContext.Request.Query.Keys.Remove("PageSize");
        }
    }
}
