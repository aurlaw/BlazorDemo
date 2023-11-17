using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDemo.Models;
using BlazorDemo.Services;

namespace BlazorDemo.Tenants
{
    public class TenantStore : ITenantStore
    {
        private readonly ITenantService _tenantService;

        public TenantStore(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        public async Task<Tenant> GetTenant(string host)
        {
            var tenant = await _tenantService.GetTenantByHost(host);
            tenant ??= await _tenantService.GetDefaultTenant();
            return tenant;
        }
    }
}