using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tests.BroadbandDeals.Core.Entites;
using Tests.BroadbandDeals.Core.Services;

namespace Tests.BroadbandDeals.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class DealsController
    {
        private readonly IDealService _dealService;

        public DealsController(IDealService dealService)
        {
            _dealService = dealService ?? throw new ArgumentNullException(nameof(dealService));
        }

        [HttpGet("")]
        public Task<IEnumerable<Deal>> GetAllAsync()
        {
            return _dealService.GetAllAsync();
        }
    }
}