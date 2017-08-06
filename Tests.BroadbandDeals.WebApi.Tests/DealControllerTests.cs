using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Tests.BroadbandDeals.Core.Entites;
using Xunit;

namespace Tests.BroadbandDeals.WebApi.Tests
{
    public class DealControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public DealControllerTests()
        {
            //Given
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Should_ControllerGetAll_ReturnsCorrectDeals()
        {
			//When
            var response = await _client.GetAsync("api/v1/deals");
            response.EnsureSuccessStatusCode();
            
            var responseString = await response.Content.ReadAsStringAsync();
            var deals = JsonConvert.DeserializeObject<List<Deal>>(responseString);
            
            //Then
            deals.Should().HaveCount(7);
            deals.Should().NotBeNull();
        }
    }
}
