using CloudComputingProject.Components;
using CloudComputingProject.Modules;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<WeatherService>();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseStaticFiles();
var log = new LogService();
string porty = log.PortList.Any() ? string.Join(", ", log.PortList) : "8080 (Domyślny)";
Console.WriteLine("APLIKACJA URUCHOMIONA");
Console.WriteLine($"Data (UTC): {log.Date:yyyy-MM-dd HH:mm:ss}");
Console.WriteLine($"Autor: {log.Author}");
Console.WriteLine($"Nasłuchiwanie na portach TCP: {porty}");
app.Run();
