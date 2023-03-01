using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleAPI.Infrastructure.Data;
using SimpleAPI.ViewModels;
using SimpleAPI.Filters;
using SimpleAPI.Shared;
using SimpleAPI.Services;
using SimpleAPI.Helpers;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUriService uriService;
        private readonly IWeatherForecastService weatherForecastService;

        public WeatherForecastController(
            IUriService uriService,
            IWeatherForecastService weatherForecastService,
            ILogger<WeatherForecastController> logger=null
            )
        {
            _logger = logger;
            this.uriService = uriService;
            this.weatherForecastService = weatherForecastService;
        }


        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = weatherForecastService.Get(validFilter);

Console.WriteLine($"pageD: {pagedData} | valid: {validFilter.PageNumber} --- {validFilter.PageSize} ---> {pagedData.Count}");
            var rng = new Random();
            var pagedReponse = PaginationHelper.CreatePagedReponse<WeatherForecastViewModel>(pagedData, validFilter, validFilter.PageLastIndex * 2, uriService, route);
    
            return Ok(pagedReponse);
        }

        

        // [Route("get/{id:int}")]
        // [HttpGet]
        // public WeatherForecastViewModel Get(int id)
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecastViewModel
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .FirstOrDefault(x=>x.Date.Date== DateTime.Now.Date.AddDays(id));
        // }
    }
}
