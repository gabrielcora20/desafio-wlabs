using MongoDB.Bson.Serialization.Conventions;
using Serilog;
using Wlabs.Infra.Data.Mappings;

namespace Wlabs.Infra.Data.Configuration
{
    public static class MongoDbInitializer
    {
        public static void Configure()
        {
            try
            {
                Log.Information($"Executando o método {nameof(Configure)} na classe: {typeof(MongoDbInitializer).Name}");

                UsuarioMap.Configure();
                EntityBaseMap.Configure();

                var pack = new ConventionPack
                {
                    new IgnoreExtraElementsConvention(true),
                    new IgnoreIfDefaultConvention(true)
                };
                ConventionRegistry.Register("Wlabs Conventions", pack, t => true);

                Log.Information("Configurações do MongoDB inicializadas");
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Houve um problema ao inicializar as configurações do MongoDB");
                throw;
            }
        }
    }

}
