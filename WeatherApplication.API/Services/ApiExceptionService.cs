using WeatherApplication.API.Interfaces;

namespace WeatherApplication.API.Services
{
    public class ApiExceptionService : Exception, IApiExceptionService
    {
        public ApiExceptionService(string v) { }
        public void ApiMessage(string exMessage) {}

        public void ApiMessage(string exMessage, Exception exception){}
    }
}
