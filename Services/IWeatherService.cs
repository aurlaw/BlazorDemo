using BlazorDemo.Models;

namespace BlazorDemo.Services;

public interface IWeatherService
{
    Task<IEnumerable<WeatherForecast>> GetWeather();

    Task<(bool,WeatherForecast?)> SaveWeather(int? id, DateOnly date, int tempAsCelsius, string? summary);

    Task DeleteWeather(int id);
}