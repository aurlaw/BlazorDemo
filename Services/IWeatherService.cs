using BlazorDemo.Models;

namespace BlazorDemo.Services;

public interface IWeatherService
{
    Task<IEnumerable<WeatherForecast>> GetWeather();
}