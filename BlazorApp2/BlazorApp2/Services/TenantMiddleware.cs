
using BlazorApp2.Data;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.Metrics;

namespace BlazorApp2.Services
{
    public class TenantMiddleware : IMiddleware
    {
        private readonly ITenantService _tenantService;
        private readonly UserManager<ApplicationUser> _userManager;

        public TenantMiddleware(ITenantService tenantService, UserManager<ApplicationUser> userManager)
        {
            _tenantService = tenantService;
            _userManager = userManager;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

             // get the tenant from the user claims
             var claim = context.User.Claims.FirstOrDefault(c => c.Type == "__tenant__");
            
            if (claim != null)
            {
                    // set the tenant
                    await _tenantService.SetTenant(claim.Value);
                }
                else
            {
                    // set the tenant to the default
                    await _tenantService.SetTenant("default");
                }
                
                

            
            await next(context);
               
        }
    }
}
