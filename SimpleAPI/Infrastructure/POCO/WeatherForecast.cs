using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
namespace SimpleAPI.Infrastructure.POCO
{
    public class WeatherForecast
    {
        [Key]
        [JsonIgnore]
        [IgnoreDataMember]
        public int ForecastID { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
