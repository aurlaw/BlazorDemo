using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDemo.Data;
using BlazorDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Services
{
    public class TenantService : ITenantService
    {
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<TenantService> _logger;

        public TenantService(ApplicationDbContext dbContext, ILogger<TenantService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Tenant> GetDefaultTenant()
        {
            return await _dbContext.Tenants.FirstAsync();
        }

        public async Task<Tenant?> GetTenantByHost(string host)
        {
           return await _dbContext.Tenants.FirstOrDefaultAsync(t => t.Host == host);
        }
    }
}