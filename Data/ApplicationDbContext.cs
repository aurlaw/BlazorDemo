using BlazorDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Data;

public class ApplicationDbContext
    (DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();
    public DbSet<Tenant> Tenants => Set<Tenant>();

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<Tenant>().Property(x => x.Key).IsRequired();
        builder.Entity<Tenant>().Property(x => x.Name).IsRequired();
        builder.Entity<Tenant>().Property(x => x.Host).IsRequired();
        builder.Entity<Tenant>().HasIndex(x => x.Key).IsUnique();

        builder.Entity<Tenant>().HasData(
            new Tenant{Id = 1, Name="Red", Key="red", Host="red.local", Created = DateTime.UtcNow},
            new Tenant{Id = 2, Name="Blue", Key="blue", Host="blue.local", Created = DateTime.UtcNow}
        );

        base.OnModelCreating(builder);
    }
}