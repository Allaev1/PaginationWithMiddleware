using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
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
        IMemoryCache memoryCache;
        int? pageSize;

        public PageSizeMiddleware(RequestDelegate next, IMemoryCache memoryCache)
        {
            this.next = next;
            this.memoryCache = memoryCache;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (!memoryCache.TryGetValue("PageSize", out pageSize))
            {
                pageSize = Convert.ToInt16(httpContext.Request.Query["PageSize"]);
                memoryCache.Set("PageSize", pageSize);
            }

            await next(httpContext);
        }
    }
}
