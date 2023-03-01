

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using SimpleAPI.Filters;
using SimpleAPI.ViewModels;

namespace SimpleAPI.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
         private static readonly string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

        public WeatherForecastService()
        {
            
        }
        public List<WeatherForecastViewModel> Get(PaginationFilter filter)
        {
            var rng = new Random();
            return Enumerable.Range(filter.PageFirstIndex, filter.PageLastIndex).Select(index => new WeatherForecastViewModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .Skip(filter.Skip)
            .Take(filter.PageSize)
            .ToList();
        }
    }
}
