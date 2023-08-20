using KLYDBMS.Application.Core;
using KLYDBMS.Application.Core.Data;
using KLYDBMS.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using Splat;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace System
{
    public static class Bootstrapper
    {
        public static void AddApplication(this IMutableDependencyResolver services, IApplication app)
        {
            services.RegisterConstant(app);
        }

        public static void AddApplicationInfo(this IMutableDependencyResolver services)
        {
            services.RegisterLazySingleton<ISoftwareInfo>(() =>
            {
                return new SoftwareInfo(Assembly.GetExecutingAssembly());
            });
        }

        public static void AddSettingsProvider(this IMutableDependencyResolver services)
        {
            AppSettings defaultAppSettings = null;

            var settingsPath = Environment.ExpandEnvironmentVariables("%APPDATA%\\KLYDBMS\\appsettings.json");
            
            defaultAppSettings = new AppSettings();

            var settingsProvider = new JsonSettingsProvider<AppSettings>(settingsPath, defaultAppSettings, new JsonSerializerOptions() { WriteIndented = true });

            services.RegisterLazySingleton<ISettingsProvider<AppSettings>>(() =>
                new JsonSettingsProvider<AppSettings>(settingsPath, defaultAppSettings, new JsonSerializerOptions() { WriteIndented = true }));
        }

        public static void AddLogging(this IMutableDependencyResolver services)
        {
            services.RegisterLazySingleton(() =>
            {
                var settings = Locator.Current.GetService<ISettingsProvider<AppSettings>>();

                var logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .WriteTo.File(Path.Combine(Environment.ExpandEnvironmentVariables(settings.Settings.LogsFolder), "log-.txt"),
                        rollingInterval: RollingInterval.Day,
                        fileSizeLimitBytes: 10 * 1024 * 1024,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                    .CreateLogger();

                return new SerilogLoggerProvider(logger).CreateLogger(nameof(KLYDBMS.Application));
            });
        }

        public static void AddDatabase(this IMutableDependencyResolver services)
        {
            var settingsProvider = Locator.Current.GetService<ISettingsProvider<AppSettings>>();

            var optionsBuilder = new DbContextOptionsBuilder<StoreDbContext>();
            optionsBuilder
                .UseSqlServer(settingsProvider.Settings.ConnectionStrings, options => options.MigrationsAssembly("KLYDBMS.Application.Core.Data"));

            services.Register(() => new StoreDbContext(optionsBuilder.Options));

            services.RegisterLazySingleton<IDesignTimeDbContextFactory<StoreDbContext>>(() => new StoreDbContextFactory());
        }

        public static void AddServices(this IMutableDependencyResolver services)
        {
            services.RegisterLazySingleton<IMUserService>(() =>
            {
                return new MUserService(Locator.Current.GetService<StoreDbContext>());
            });
        }

        public static void ConfigureDatabase(this IReadonlyDependencyResolver services)
        {
            var db = services.GetService<StoreDbContext>();
            db.Database.Migrate();
        }
    }
}
