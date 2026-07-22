using AdoptionCenterDA.Web.Components;
using AdoptionCenterDA.Web.Data;
using AdoptionCenterDA.Web.Models;
using AdoptionCenterDA.Web.Services;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Database

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")));


// Identity

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 6;
        options.Password.RequireDigit = true;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = false;

        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


// Razor Components

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();


// Authentication

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
})
.AddIdentityCookies();

builder.Services.AddAuthorization();


// Application Services

builder.Services.AddSingleton<IPetService, PetService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IAdoptionService, AdoptionService>();


var app = builder.Build();


// Configure HTTP Request Pipeline

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
