using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WeatherApplication.API.Models
{

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Coord
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int SeaLevel { get; set; }
        public int GrndLevel { get; set; }
    }

    public class Rain
    {
        [JsonProperty("1h")]
        public double OneHour { get; set; }
    }

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

    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string? Main { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }
    }
}
