using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;
using System;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
public async Task<IActionResult> Index(string city)
{
    try
    {
        if (string.IsNullOrEmpty(city))
        {
            ViewBag.Error = "Пожалуйста, введите город";
            return View();
        }

        var weather = await _weatherService.GetWeatherAsync(city);
        if (weather == null)
        {
            ViewBag.Error = "Не удалось получить данные о погоде";
            return View();
        }
        
        return View(weather);
    }
    catch (Exception ex)
    {
        ViewBag.Error = $"Произошла ошибка: {ex.Message}";
        return View();
    }
}
    }
}
