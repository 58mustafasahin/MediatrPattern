using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrWebApi.ServiceInstallers
{
    public interface IInstaller
    {
        //Install services to ConfigureServices from startup
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
