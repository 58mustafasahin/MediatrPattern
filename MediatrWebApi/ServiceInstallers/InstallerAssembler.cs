using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MediatrWebApi.ServiceInstallers
{
    /// <summary>
    /// Assembly all installers to a Startup.cs ConfigureServices
    /// </summary>
    public static class InstallerAssembler
    {
        public static void AddInstallerServicesInAssembly(this IServiceCollection services,
            IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes
                .Where(p => typeof(IInstaller).IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>()
                .ToList();
            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
