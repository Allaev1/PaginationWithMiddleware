﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagination.WebApi.Filter;
using Pagination.WebApi.Models;

namespace Pagination.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(PaginationFilter filter = null)
        {
            return default;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return default;
        }
    }
}