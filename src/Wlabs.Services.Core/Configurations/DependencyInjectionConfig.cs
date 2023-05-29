using Microsoft.Extensions.DependencyInjection;
using Wlabs.Infra.CrossCutting.IoC;

namespace Wlabs.Services.Core.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}