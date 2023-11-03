using BlazorDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Data;

public class ApplicationDbContext
    (DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();
}