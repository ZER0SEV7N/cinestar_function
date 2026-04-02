using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Hosting;
using cinestar_function.Content.Database;
using cinestar_function.Content.Datos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

string cadena = builder.Configuration.GetConnectionString("CinestarDB");
builder.Services.AddScoped<Conexion>(provider => new Conexion(cadena));
builder.Services.AddScoped<daoCinestar>();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

builder.Build().Run();
