using DiceWatch.ViewModels;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace DiceWatch;

/// <summary>
/// Static class entry point in to a .NET Maui Application.
/// </summary>
// This is where you configure your application's services and the main
// page it should display.
public static class MauiProgram
{
    /// <summary>
    /// Starting function that creates a <code>MauiApp</code> instance.  
    /// </summary>
    /// <returns></returns>
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

#if DEBUG
        builder.Logging.AddDebug();
#endif
        // Any time we can't use a 0-parameter constructor, we should make sure 
        // the DI Services are aware of the type.  As our view-model(s) need
        // services injected, they're explicitly set up now:
        builder.Services.AddTransient<MainMenuViewModel>();

        // Our views now get the View-Models injected in their code-behind file.
        // That means "same deal" as all other classes and they will need explicit
        // wire-up in the service build-up:
        builder.Services.AddTransient<MainMenu>();

        builder.Services.AddFluxor(o =>
        {
            // Standard Fluxor boiler plate code to find reducers
            o.ScanAssemblies(typeof(MauiProgram).Assembly);

            // By default, the store-lifetime is "scoped". In a mobile app this means 
            // that by the time it's needed, the store has been rebuilt, without rescanning
            // for the reducers.  By explicitly setting the store-lifetime as a singleton,
            // the registered reducers are ready to be consumed by the time actions start 
            // getting dispatched.  
            // (See also: https://github.com/mrpmorris/Fluxor/issues/317#issuecomment-1141519409 )
            o.WithLifetime(StoreLifetime.Singleton);
        });


        return builder.Build();
    }
}