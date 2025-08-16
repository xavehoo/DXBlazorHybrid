using DevExpress.Maui;
using DXBlazorHybrid.Services;
using DXBlazorHybrid.Shared.Services;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace DXBlazorHybrid;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseDevExpress(useLocalization: false)
            .UseDevExpressCollectionView()
            .UseDevExpressControls()
            .UseDevExpressEditors()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddSingleton<IFormFactor, FormFactor>();
        builder.Services.AddSingleton<WeatherService>();
        builder.Services.AddSingleton<ILocationService, MauiLocationService>();
        builder.Services.AddSingleton<HttpClient>(sp => new HttpClient());

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddDevExpressBlazor();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
