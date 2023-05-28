using MongoDB.Bson.Serialization.Conventions;
using Wlabs.Infra.Data.Mappings;

namespace Wlabs.Infra.Data.Configuration
{
    public static class MongoDbInitializer
    {
        public static void Configure()
        {
            UsuarioMap.Configure();
            EntityBaseMap.Configure();

            // Conventions
            var pack = new ConventionPack
                {
                    new IgnoreExtraElementsConvention(true),
                    new IgnoreIfDefaultConvention(true)
                };
            ConventionRegistry.Register("Wlabs Conventions", pack, t => true);
        }
    }

}
