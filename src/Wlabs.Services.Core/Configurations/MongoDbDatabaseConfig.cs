using Microsoft.Extensions.DependencyInjection;
using Wlabs.Infra.Data.Configuration;

namespace Wlabs.Services.Core.Configurations
{
    public static class MongoDbDatabaseConfig
    {
        public static void AddMongoDbConfiguration(this IServiceCollection services)
        {
            MongoDbInitializer.Configure();
        }
    }
}
