using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using KLYDBMS.Application.Core;
using KLYDBMS.Application.Core.ViewModels;
using KLYDBMS.Application.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Splat;
using System;

namespace KLYDBMS;

public partial class App : Avalonia.Application, IApplication
{
    public override void Initialize()
    {
        Startup.ConfigureServices(Locator.CurrentMutable, this);

        var logger = Locator.Current.GetService<Microsoft.Extensions.Logging.ILogger>();
        logger.LogInformation("Starting aplication...");

        Startup.Configure(Locator.Current);
        logger.LogInformation("Services configured!");

        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    public void Shutdown()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.Shutdown();
        }
    }
}
