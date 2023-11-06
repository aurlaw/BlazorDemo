using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Models;

public sealed class Forecast
{
    public int? Id { get; set; }
    [Required] 
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    [Required]
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }

    public static Forecast FromEntity(WeatherForecast forecast)
    {
        return new Forecast
        {
            Id = forecast.Id,
            Date = forecast.Date,
            TemperatureC = forecast.TemperatureC,
            Summary = forecast.Summary
        };
    }

    public WeatherForecast ToEntity()
    {
        return new WeatherForecast
        {
            Id = Id ?? 0,
            Date = Date,
            TemperatureC = TemperatureC,
            Summary = Summary
        };
    }
    
}