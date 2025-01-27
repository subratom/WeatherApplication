namespace WeatherApplication.API.Interfaces
{
    public interface IApiExceptionService
    {
        void ApiMessage(string exMessage);

        void ApiMessage(string exMessage, Exception exception);
    }
}
