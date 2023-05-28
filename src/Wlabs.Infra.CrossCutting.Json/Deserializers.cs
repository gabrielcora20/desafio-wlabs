using Newtonsoft.Json;
using Wlabs.Domain.Entities;

namespace Wlabs.Infra.CrossCutting.Json
{
    public static class Deserializers
    {
        public static TEntity Deserialize<TEntity>(this string json) where TEntity : EntityBase
        {
            return JsonConvert.DeserializeObject<TEntity>(json);
        }
    }
}
