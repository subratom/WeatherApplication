using WeatherApplication.API.Models;

namespace WeatherApplication.API.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<WeatherForcastRoot> GetWeatherForecasts(string cityName);
    }
}