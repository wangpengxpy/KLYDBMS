using System.Reflection;

namespace KLYDBMS.Application.Core
{
    public class SoftwareInfo : ISoftwareInfo
    {
        public string Name { get; }
        public string Organization { get; }
        public string Copyright { get; }
        public string Version { get; }
        public string FileVersion { get; }
        public DateTime Created { get; }

        public SoftwareInfo(Assembly assembly)
        {
            Name = assembly.GetCustomAttribute<AssemblyProductAttribute>().Product;
            Organization = assembly.GetCustomAttribute<AssemblyCompanyAttribute>().Company;
            Copyright = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
            Version = assembly.GetName().Version.ToString();
            FileVersion = assembly.GetName().Version.ToString();
            Created = DateTime.Now;
        }
    }
}
