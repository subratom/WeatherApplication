using WeatherApplication.API.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApplication.API.Models;
using WeatherForcast.API.Models;


namespace WeatherForcast.Tests
{
    [TestClass]
    public sealed class WeatherForcastServiceTests
    {
        private Mock<IWeatherForecastService> mockWeatherForecastService;
        private HttpClient httpClient;
        private string apiUrl = "https://api.weather.com";

        [TestInitialize]
        public void Setup()
        {
            mockWeatherForecastService = new Mock<IWeatherForecastService>();
            httpClient = new HttpClient();
        }

        [TestMethod]
        public async Task WeatherForcast_ReturnDataForBoston()
        {
            string cityName = "Boston";

            WeatherForcastRoot expectedForecasts = new WeatherForcastRoot()
            {
                City = "Boston",
                Temp = 50,
                TempMin = 45,
                TempMax = 55,
                Humidity = 50,
                Pressure = 30,
                WindSpeed = 10,
                Weather = "Cloudy",
                WeatherDescription = "Cloudy",
                WeatherIcon = "04d",
                Date = DateTime.Now.ToString(),
                System = new Sys()
                {
                    Country = "US",
                    Sunrise = 1630000000,
                    Sunset = 1630000000,
                    Type = 1
                },
                Coord = new Coord()
                {
                    Latitude = 42.3601,
                    Longitude = 71.0589
                },
                Clouds = new Clouds()
                {
                    All = 90
                },
                Wind = new Wind()
                {
                    Speed = 10
                },
                Main = new Main()
                {
                    Temp = 50,
                    FeelsLike = 50,
                    TempMin = 45,
                    TempMax = 55,
                    Pressure = 30,
                    Humidity = 50,
                    SeaLevel = 30,
                    GrndLevel = 30
                },
            };


            mockWeatherForecastService.Setup(service => service.GetWeatherForecasts(cityName))
                .ReturnsAsync(expectedForecasts);

            // Act
            var result = await mockWeatherForecastService.Object.GetWeatherForecasts(cityName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedForecasts.City, result.City);
        }
    }
}
