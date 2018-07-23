using System.Threading.Tasks;
using Weather_App.Classes;

namespace WeatherMVVM.Core.Services
{
    public interface IWeatherService
    {
        Task<Forecast> GetForecastRequest(string city);
    }
}