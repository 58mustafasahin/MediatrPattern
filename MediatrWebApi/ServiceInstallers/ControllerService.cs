using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrWebApi.ServiceInstallers
{
    /// <summary>
    /// Install controllers
    /// </summary>
    public class ControllerService : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.AddControllers();
        }
    }
}
