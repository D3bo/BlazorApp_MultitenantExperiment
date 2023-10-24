using BlazorApp2.Client;
using BlazorApp2.Client.Pages;
using BlazorApp2.Components;
using BlazorApp2.Data;
using BlazorApp2.Identity;
using BlazorApp2.Services;
using BlazorApp2.Shared.Service;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();



builder.Services.AddHttpContextAccessor();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<UserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddScoped<TenantMiddleware> ();
builder.Services.AddTransient<IProductServices, ProductServices>();

builder.Services.AddScoped<ITenantService, TenantService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlite(connectionString));

builder.Services.AddDbContextFactory<SingleDbContext>(opts => opts.UseSqlite(connectionString), ServiceLifetime.Scoped);
builder.Services.AddDbContextFactory<MultipleDbContext>((sp, op) =>
{
    var ts = sp.GetRequiredService<ITenantService>();
    var tenantcs = ts.GetTenantConnectionString();
    op.UseSqlServer(tenantcs);
}, ServiceLifetime.Transient);


builder.Services.AddDatabaseDeveloperPageExceptionFilter();


//TODO gestire sia authenticazione api che razor
//builder.Services
//   .AddIdentityApiEndpoints<ApplicationUser>()  
//   .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)   
    .AddIdentityCookies();




builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true) 
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender, NoOpEmailSender>();


builder.Services.AddTransient<ICustomerService, CustomerService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();



app.UseMiddleware<TenantMiddleware>();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.MapControllers();
//app.MapGroup("api/account").MapIdentityApi<ApplicationUser>();

app.Run();
