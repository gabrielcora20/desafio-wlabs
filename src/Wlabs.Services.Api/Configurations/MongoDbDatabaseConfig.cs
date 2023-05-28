using Wlabs.Infra.Data.Configuration;

namespace Wlabs.Services.Api.Configurations
{
    public static class MongoDbDatabaseConfig
    {
        public static void AddMongoDbConfiguration(this IServiceCollection services)
        {
            MongoDbInitializer.Configure();
        }
    }
}
