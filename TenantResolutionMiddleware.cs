using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDemo.Models;
using BlazorDemo.Services;
using BlazorDemo.Tenants;

namespace BlazorDemo
{
    public class TenantResolutionMiddleware
    {
        private readonly ILogger<TenantResolutionMiddleware> _logger;
        private readonly RequestDelegate _next;
        public TenantResolutionMiddleware(RequestDelegate next, ILogger<TenantResolutionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        
        public async Task Invoke(HttpContext context, ITenantContext tenantSetter, ITenantStore tenantStore)
        {
            var tenantHost = GetTenantFrom(context.Request);
            
            // _logger.LogInformation("tenantHost: {0}", tenantHost);

            Tenant tenant = await tenantStore.GetTenant(tenantHost);

            tenantSetter.CurrentTenant = tenant;
            // _logger.LogInformation("tenantSetter: {0}", tenant.Name);

            await _next(context);
        }

        private string GetTenantFrom(HttpRequest httpRequest) 
        {
            return httpRequest.Host.Host;
        }
    }
}
