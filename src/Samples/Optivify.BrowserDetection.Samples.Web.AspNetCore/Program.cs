using Optivify.BrowserDetection;
using Optivify.BrowserDetection.AspNetCore.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddHttpContextAccessor();

// Add browser detection
services.AddBrowserDetection(configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

var detectionOptions = app.Services.GetRequiredService<BrowserDetectionOptions>();

if (!detectionOptions.SkipClientHintsDetection)
{
    app.UseClientHintsDetection();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
