using Wlabs.Infra.Data.Configuration;

namespace Wlabs.Services.ViaCep.Configurations
{
    public static class MongoDbDatabaseConfig
    {
        public static void AddMongoDbConfiguration(this IServiceCollection services)
        {
            MongoDbInitializer.Configure();
        }
    }
}
