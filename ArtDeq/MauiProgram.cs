using Microsoft.Extensions.Logging;
using ArtDeq.Services.Abstractions;
using ArtDeq.Services.Dummy;
using ArtDeq.Services;
using ArtDeq.ViewModels;
using ArtDeq.Views;

namespace ArtDeq;

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

        // Repositories
        builder.Services.AddSingleton<IArtworkRepository, DummyArtworkRepository>();
        builder.Services.AddSingleton<IChatRepository, DummyChatRepository>();
        builder.Services.AddSingleton<ICollectionRepository, PreferencesCollectionRepository>();

        // ViewModels
        builder.Services.AddTransient<FeedViewModel>();

        // Pages
        builder.Services.AddTransient<FeedPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
