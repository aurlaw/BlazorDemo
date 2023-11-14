using BlazorDemo.Models;

namespace BlazorDemo.Services;

public interface IWeatherService
{
    Task<PaginatedResult<WeatherForecast>> GetWeather(int? page = null, int pageSize = 15);

    Task<(bool,WeatherForecast?)> SaveWeather(int? id, DateOnly date, int tempAsCelsius, string? summary);

    Task DeleteWeather(int id);
}