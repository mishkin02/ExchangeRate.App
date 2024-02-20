using Microsoft.Extensions.Logging;
using ExchangeRate.ViewModel;
using ExchangeRate.Model;
using ExchangeRate.Services;


namespace ExchangeRate;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddSingleton<ValuteService>();
        builder.Services.AddSingleton<ValutesViewModel>();
        builder.Services.AddSingleton<MainPage>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
