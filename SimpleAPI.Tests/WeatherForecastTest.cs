using System;
using Xunit;
using System.Collections.Generic;
using Moq;
using System.Linq;
using SimpleAPI.ViewModels;
using SimpleAPI.Controllers;

namespace SimpleAPI.Tests
{
    public class WeatherForecastTest
    {
        private readonly WeatherForecastController _weatherForecastController;
        private Mock<List<WeatherForecastViewModel>> _mockWeatherForecastList;

        public WeatherForecastTest()
        {
            _weatherForecastController = new WeatherForecastController();
            _mockWeatherForecastList = new Mock<List<WeatherForecastViewModel>>();
        }


        [Fact]
        public void WeatherForecastGetTest()
        {
            //arrange
            var mockForecasts = new List<WeatherForecastViewModel> { 
                new WeatherForecastViewModel{
                    Date = DateTime.Now,
                    TemperatureC = 30,
                    Summary = "Cool"
                },
                new WeatherForecastViewModel{
                    Date = DateTime.Now,
                    TemperatureC = 55,
                    Summary = "Scorching"
                }
            };

            _mockWeatherForecastList.Object.AddRange(mockForecasts);

            //act
            var result = _weatherForecastController.Get();

            //assert
            var model = Assert.IsAssignableFrom<IEnumerable<WeatherForecastViewModel>>(result);
            Assert.Equal(5,model.ToList().Count);
        }
    }
}
