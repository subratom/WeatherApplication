using Newtonsoft.Json;
using System.Web;
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

            var encodedCityName = HttpUtility.UrlEncode(cityName);
            var requestUri = $"{apiUrl}&q=City{encodedCityName}";

            try
            {
                var response = await httpClient.GetAsync(requestUri);
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApiExceptionService($"Error while fetching weather forecast. Status code is {response.StatusCode}");
                }

                var content = response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(content.ToString()))
                {
                    throw new ApiExceptionService("Received empty content while fetching weather forecast");
                }
                var deserializedContent = JsonConvert.DeserializeObject<WeatherForcastRoot>(content.Result);
                if (deserializedContent == null)
                {
                    throw new ApiExceptionService("Error while deserializing weather forecast");
                }
                weatherForecast = deserializedContent;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching weather forecast", ex);
            }
            return weatherForecast;
        }
    }
}
