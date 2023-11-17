using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDemo.Models;

namespace BlazorDemo.Services
{
    public interface ITenantService
    {
        Task<Tenant?> GetTenantByHost(string host);
        Task<Tenant> GetDefaultTenant();
    }
}