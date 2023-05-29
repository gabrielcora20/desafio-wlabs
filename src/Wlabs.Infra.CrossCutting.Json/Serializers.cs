using Newtonsoft.Json;

namespace Wlabs.Infra.CrossCutting.Json
{
    public static class Serializers
    {
        public static string Serialize<TEntity>(this TEntity entity) where TEntity : class
        {
            return JsonConvert.SerializeObject(entity, Formatting.Indented);
        }
    }
}
