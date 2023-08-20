using Avalonia;
using Avalonia.ReactiveUI;
using KLYDBMS.Icons.Avalonia.MMaterialDesign;
using Projektanker.Icons.Avalonia;
using Projektanker.Icons.Avalonia.FontAwesome;
using Projektanker.Icons.Avalonia.MaterialDesign;
using ReactiveUI;
using Splat;
using System;
using System.Reflection;

namespace KLYDBMS;

class Program
{
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    public static AppBuilder BuildAvaloniaApp()
    {
        Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetExecutingAssembly());

        IconProvider.Current
            .Register<FontAwesomeIconProvider>()
            .Register<MaterialDesignIconProvider>()
            .Register<MMaterialDesignIconProvider>();

        return AppBuilder.Configure<App>()
             .UsePlatformDetect()
             .WithInterFont()
             .LogToTrace()
             .UseReactiveUI();
    }
}
