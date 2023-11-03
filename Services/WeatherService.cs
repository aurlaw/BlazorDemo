using System.Collections;
using BlazorDemo.Data;
using BlazorDemo.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Services;

public class WeatherService : IWeatherService
{

    private readonly ApplicationDbContext _dbContext;

    public WeatherService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeather()
    {
        await Task.Delay(500);

        IList<WeatherForecast> data = new List<WeatherForecast>();
        if (!_dbContext.WeatherForecasts.Any())
        {
            var startDate = DateOnly.FromDateTime(DateTime.Now);
            var summaries = new[] {"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"};
            data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            }).ToList();
            foreach (var weatherForecast in data)
            {
                _dbContext.WeatherForecasts.Add(weatherForecast);
            }

            await _dbContext.SaveChangesAsync();
        }

        if (!data.Any())
        {
            data = await _dbContext.WeatherForecasts.ToListAsync();
        }

        return data;

    }
}