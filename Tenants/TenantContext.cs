using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDemo.Models;

namespace BlazorDemo.Tenants
{
    public interface ITenantContext
    {
        Tenant CurrentTenant { get; set;}
    }

    public class TenantContext : ITenantContext
    {
        public Tenant CurrentTenant { get; set; }
    }
}