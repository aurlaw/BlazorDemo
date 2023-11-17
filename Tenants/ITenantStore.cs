using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDemo.Models;

namespace BlazorDemo.Tenants
{
    public interface ITenantStore
    {
        Task<Tenant> GetTenant(string host);
    }
}