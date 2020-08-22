using SimpleAPI.Infrastructure.POCO;
using System;
using System.Linq;

namespace SimpleAPI.Infrastructure.Data
{
    public static class SeedData
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public static void PopulateTestData(ApplicationDbContext dbContext)
        {
            
            var rng = new Random();

            var forecasts= Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            dbContext.Forecast.AddRange(forecasts);
            dbContext.SaveChanges();
        }
    }
}
