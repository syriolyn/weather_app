using System.Threading.Tasks;
using WeatherApp.Models;
using Newtonsoft.Json;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        Task<WeatherViewModel> GetWeatherAsync(string city);
    }
}