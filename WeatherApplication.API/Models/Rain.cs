using Newtonsoft.Json;

namespace WeatherForcast.API.Models
{
    public class Rain
    {
        [JsonProperty("1h")]
        public double OneHour { get; set; }
    }
}
