using KLYDBMS.Application.Core;
using Splat;

namespace System
{
    public static class Startup
    {
        public static void ConfigureServices(
            IMutableDependencyResolver services, IApplication app)
        {
            services.AddApplication(app);
            services.AddApplicationInfo();
            services.AddSettingsProvider();
            services.AddLogging();
            services.AddDatabase();
            services.AddServices();
        }

        public static void Configure(IReadonlyDependencyResolver services)
        {
            services.ConfigureDatabase();
        }
    }
}
