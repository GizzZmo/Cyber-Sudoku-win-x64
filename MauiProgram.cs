// --- File: MauiProgram.cs ---
// This is the main entry point for the .NET MAUI application.
// It configures and builds the app, registering services for dependency injection.
using Microsoft.Extensions.Logging;

namespace CyberSudoku.MAUI;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif
        // Register services and view models for dependency injection
        // builder.Services.AddSingleton<IDatabaseService, SqliteService>();
        // builder.Services.AddSingleton<SudokuBoardViewModel>();
        // builder.Services.AddSingleton<MainPage>();

        return builder.Build();
    }
}

// --- File: App.xaml.cs ---
// The main application class, inheriting from Application.
namespace CyberSudoku.MAUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        // The main page of the application is set here.
        MainPage = new AppShell();
    }
}
