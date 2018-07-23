using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Weather_App.Classes;

namespace WeatherMVVM.Core.Services
{
    public class WeatherService : IWeatherService
    {
        public async Task<Forecast> GetForecastRequest(string city)
        {
            // Send GET request
            var client = new HttpClient();
            var url = "http://api.openweathermap.org/data/2.5/weather?units=metric&q=";
            var api_key = "&APPID=a8999f0f765e8de3e708c26e72f8e03b";
            var uri = url + city + api_key;
            var response = await client.GetStringAsync(uri);

            //Handle Response
            var forecast = JsonConvert.DeserializeObject<Forecast>(response);

            //Generate Output
            return forecast;
        }
    }
}