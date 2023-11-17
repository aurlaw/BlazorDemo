using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDemo.Models;
using BlazorDemo.Services;
using BlazorDemo.Tenants;
using Microsoft.AspNetCore.Components;

namespace BlazorDemo
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMultitenancy(this IServiceCollection services)
        {
            services.AddScoped<ITenantContext, TenantContext>();
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<ITenantStore, TenantStore>();    

            // // services.AddCascadingValue<ITenantContext>(provider =>  provider.GetRequiredService<TenantContext>());
            // services.AddCascadingValue(sp =>
            // {
            //     var tenantContext = sp.GetRequiredService<ITenantContext>();
            //     var source = new CascadingValueSource<Tenant>(tenantContext.CurrentTenant, isFixed: true);                
            //     return source;
            // });

            return services;
        }                
    }
}