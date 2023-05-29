using Newtonsoft.Json;
using Serilog;

namespace Wlabs.Infra.CrossCutting.Json
{
    public static class Serializers
    {
        public static string Serialize<TEntity>(this TEntity entity) where TEntity : class
        {
            Log.Information($"Executando o método {nameof(Serialize)} na classe: {typeof(Serializers).Name}");

            return JsonConvert.SerializeObject(entity, Formatting.Indented);
        }
    }
}
