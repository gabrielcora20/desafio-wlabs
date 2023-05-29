using Newtonsoft.Json;
using Serilog;

namespace Wlabs.Infra.CrossCutting.Json
{
    public static class Deserializers
    {
        public static TEntity Deserialize<TEntity>(this string json) where TEntity : class
        {
            Log.Information($"Executando o método {nameof(Deserialize)} na classe: {typeof(Deserializers).Name}");

            return JsonConvert.DeserializeObject<TEntity>(json);
        }
    }
}
