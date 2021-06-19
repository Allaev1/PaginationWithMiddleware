using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.WebApi.Middleware
{
    public static class PageSizeMiddlewareExtensions
    {
        public static IApplicationBuilder UsePageSize(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PageSizeMiddleware>();
        }
    }
}
