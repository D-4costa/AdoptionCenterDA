using AdoptionCenterDA.Web.Components;
using AdoptionCenterDA.Web.Services;

var builder = WebApplication.CreateBuilder(args);


// Add Razor components
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();


// Register services
builder.Services.AddSingleton<IPetService, PetService>();


var app = builder.Build();


// Configure HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();
