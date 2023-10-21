
using BlazorApp2.Data;
using System.Diagnostics.Metrics;

namespace BlazorApp2.Services
{
    public class TenantMiddleware : IMiddleware
    {
        private readonly ITenantService _tenantService;

        public TenantMiddleware(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Query.TryGetValue("tenant", out var values))
            {
                _tenantService.SetTenant(values.FirstOrDefault());
            }
            else
            {
                // set default tenant
               _tenantService.SetTenant("Default");
            }
            await next(context);
        }
    }
}
