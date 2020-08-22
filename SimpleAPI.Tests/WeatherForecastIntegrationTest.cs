using Newtonsoft.Json;
using SimpleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SimpleAPI.Tests
{
    public class WeatherForecastIntegrationTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public WeatherForecastIntegrationTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanGetPlayers()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/WeatherForecast/Get");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var players = JsonConvert.DeserializeObject<IEnumerable<WeatherForecastViewModel>>(stringResponse);
            var date = DateTime.Now.Date;
            Assert.Contains(players, p => p.TemperatureC >= -20 || p.TemperatureC <= 55);
            Assert.Contains(players, p => p.Date >= date.AddDays(1) || p.Date <= date.AddDays(5));
        }
    }
}