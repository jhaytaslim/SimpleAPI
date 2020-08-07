using System;
using Xunit;
using SimpleAPI;
using System.Collections.Generic;
using Moq;
using SimpleAPI.Controllers;
using System.Linq;

namespace SimpleAPI.Tests
{
    public class WeatherForecastTest
    {
        private readonly WeatherForecastController _weatherForecastController;
        private Mock<List<WeatherForecast>> _mockWeatherForecastList;

        public WeatherForecastTest()
        {
            _weatherForecastController = new WeatherForecastController();
            _mockWeatherForecastList = new Mock<List<WeatherForecast>>();
        }


        [Fact]
        public void WeatherForecastGetTest()
        {
            //arrange
            var mockForecasts = new List<WeatherForecast> { 
                new WeatherForecast{
                    Date = DateTime.Now,
                    TemperatureC = 30,
                    Summary = "Cool"
                },
                new WeatherForecast{
                    Date = DateTime.Now,
                    TemperatureC = 55,
                    Summary = "Scorching"
                }
            };

            _mockWeatherForecastList.Object.AddRange(mockForecasts);

            //act
            var result = _weatherForecastController.Get();

            //assert
            var model = Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(result);
            Assert.Equal(5,model.ToList().Count);
        }
    }
}
