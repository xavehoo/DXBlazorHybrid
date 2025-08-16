using DXBlazorHybrid.Shared.Services;
using DXBlazorHybrid.Web.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddSingleton<ILocationService, WebLocationService>();
builder.Services.AddDevExpressBlazor();

await builder.Build().RunAsync();
