using CarsConsulting;
using CarsConsulting.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

app.UsePathBase("/Api");

MainDbContext? mainDbContext = app.Services.GetService<MainDbContext>();
ILogger<Startup>? logger = app.Services.GetService <ILogger<Startup>>();

startup.Configure(app, mainDbContext, logger);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();