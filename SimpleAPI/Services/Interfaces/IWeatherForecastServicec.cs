
using System;
using System.Collections.Generic;
using SimpleAPI.Filters;
using SimpleAPI.ViewModels;

namespace SimpleAPI.Services
{
    public interface IWeatherForecastService
    {
        public List<WeatherForecastViewModel> Get(PaginationFilter filter);
    }
}
