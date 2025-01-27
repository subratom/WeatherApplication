namespace WeatherForcast.API.Models
{
    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }
}
