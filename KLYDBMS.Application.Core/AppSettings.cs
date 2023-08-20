namespace KLYDBMS.Application.Core
{
    public class AppSettings
    {
        public Guid ApplicationId { get; set; } = Guid.NewGuid();

        public string LogsFolder { get; set; } = "%APPDATA%\\KLYDBMS\\Logs";

        public string ConnectionStrings { get; set; }
    }
}
