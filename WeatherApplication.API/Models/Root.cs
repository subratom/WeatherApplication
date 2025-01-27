using Newtonsoft.Json;
using System.Runtime.Serialization;
using WeatherForcast.API.Models;

namespace WeatherApplication.API.Models
{
    public class WeatherForcastRoot
    {
        public string City { get; set; }
        public double Temp { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public double WindSpeed { get; set; }
        public string Weather { get; set; }
        public string WeatherDescription { get; set; }
        public string WeatherIcon { get; set; }
        public string Date { get; set; }
        public Sys System { get; set; }
        public Coord Coord { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public Main Main { get; set; }

        public Rain Rain { get; set; }
    }
}
