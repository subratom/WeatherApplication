using Newtonsoft.Json;
using WeatherApplication.API.Interfaces;
using WeatherApplication.API.Models;

namespace WeatherApplication.API.Services
{
    public class WeatherForcastService : IWeatherForecastService
    {
        private readonly IWeatherForecastService weatherForecastService;
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "https://localhost:44300/weatherforecast";

        public WeatherForcastService()
        {
            throw new ApiExceptionService("Please provider required dependencies");
        }

        public WeatherForcastService(IWeatherForecastService _weatherForecastService, HttpClient _httpClient, string _apiUrl)
        {
            this.weatherForecastService = _weatherForecastService;
            this.httpClient = _httpClient;
            this.apiUrl = _apiUrl;
        }

        public async Task<WeatherForcastRoot> GetWeatherForecasts(string cityName)
        {
            WeatherForcastRoot weatherForecast = new();

            try
            {
                var response = await httpClient.GetAsync($"{apiUrl}&q=City{cityName}");
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    if (content != null)
                    {
                        var deserializedContent = JsonConvert.DeserializeObject<WeatherForcastRoot>(content);
                        if (deserializedContent != null)
                        {
                            weatherForecast = deserializedContent;
                        }
                        else
                        {
                            throw new ApiExceptionService("Error while deserializing weather forecast");
                        }
                    }
                    else
                    {
                        throw new ApiExceptionService("Received empty content while fetching weather forecast");
                    }
                }
                else
                {
                    throw new ApiExceptionService("Error while fetching weather forecast");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching weather forecast", ex);
            }
            return weatherForecast;
        }
    }
}
