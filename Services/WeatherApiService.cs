using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json; // Эта строка должна быть
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherApiService : IWeatherService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public WeatherApiService(IConfiguration config, HttpClient httpClient)
        {
            _config = config;
            _httpClient = httpClient;
        }

        public async Task<WeatherViewModel> GetWeatherAsync(string city)
        {
            string apiKey = _config["WeatherApi:ApiKey"];
            string baseUrl = _config["WeatherApi:BaseUrl"];
            
            var response = await _httpClient.GetAsync($"{baseUrl}current.json?key={apiKey}&q={city}&lang=ru");
            
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<WeatherApiResponse>(json);

            return new WeatherViewModel
            {
                City = data.Location.Name,
                Country = data.Location.Country,
                Temperature = data.Current.Temp_c,
                Description = data.Current.Condition.Text,
                Icon = data.Current.Condition.Icon,
                Humidity = data.Current.Humidity,
                WindSpeed = data.Current.Wind_kph / 3.6f
            };
        }
    }
}