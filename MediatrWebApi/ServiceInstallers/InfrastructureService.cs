using MediatrInfrastructure.ServiceInstaller;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrWebApi.ServiceInstallers
{
    public class InfrastructureService : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddService();
        }
    }
}
