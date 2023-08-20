namespace KLYDBMS.Application.Core
{
    public interface ISoftwareInfo
    {
        string Name { get; }
        string Organization { get; }
        string Copyright { get; }
        string Version { get; }
        string FileVersion { get; }
        DateTime Created { get; }
    }
}
