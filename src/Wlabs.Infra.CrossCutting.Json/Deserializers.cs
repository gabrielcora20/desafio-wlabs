using Newtonsoft.Json;

namespace Wlabs.Infra.CrossCutting.Json
{
    public static class Deserializers
    {
        public static TEntity Deserialize<TEntity>(this string json)
        {
            return JsonConvert.DeserializeObject<TEntity>(json);
        }
    }
}
