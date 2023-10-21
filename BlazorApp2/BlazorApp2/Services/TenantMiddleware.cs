
using BlazorApp2.Data;
using System.Diagnostics.Metrics;

namespace BlazorApp2.Services
{
    public class TenantMiddleware : IMiddleware
    {
        private readonly TenantService _tenantService;

        public TenantMiddleware(TenantService tenantService)
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
