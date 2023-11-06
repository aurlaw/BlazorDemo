using System.Collections;
using BlazorDemo.Data;
using BlazorDemo.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Services;

public class WeatherService : IWeatherService
{

    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<WeatherService> _logger;
    public WeatherService(ApplicationDbContext dbContext, ILogger<WeatherService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeather()
    {
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
            data = await _dbContext.WeatherForecasts.OrderBy(w => w.Date).ToListAsync();
        }

        return data;

    }

    public async Task<(bool,WeatherForecast?)> SaveWeather(int? id, DateOnly date, int tempAsCelsius, string? summary)
    {
        try
        {
            var weatherItem = await _dbContext.WeatherForecasts.FindAsync(id);
            if(weatherItem is null) 
            {
                weatherItem = new WeatherForecast();
                _dbContext.WeatherForecasts.Add(weatherItem);
            }
            weatherItem.Date = date;
            weatherItem.TemperatureC = tempAsCelsius;
            weatherItem.Summary = summary;

            await _dbContext.SaveChangesAsync();

            return (true, weatherItem);
            
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            
            return(false,null);
        }        
    }

    public async Task DeleteWeather(int id) 
    {
        await _dbContext.WeatherForecasts.Where(x => x.Id == id).ExecuteDeleteAsync();
    }
}