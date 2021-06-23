using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Pagination.WebApi.Data;
using Pagination.WebApi.Filter;
using Pagination.WebApi.Helpers;
using Pagination.WebApi.Models;
using Pagination.WebApi.Services;
using Pagination.WebApi.Wrappers;

namespace Pagination.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly NorthwindContext context;
        private readonly IUriService uriService;

        public CustomerController(NorthwindContext context, IUriService uriService)
        {
            this.context = context;
            this.uriService = uriService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] uint pageNumber, [FromQuery] uint pageSize)
        {
            var route = Request.Path.Value;

            var validFilter = new PaginationFilter((int)pageNumber, (int)pageSize);

            var pagedData = await context.Customers
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .ToListAsync();

            var totalRecords = await context.Customers.CountAsync();

            var pagedReponse = PaginationHelper.CreatePagedReponse<Customer>(pagedData, validFilter, totalRecords, uriService, route);

            return Ok(pagedReponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var customer = await context.Customers.Where(a => a.CustomerId == id).FirstOrDefaultAsync();
            return Ok(new Response<Customer>(customer));
        }
    }
}