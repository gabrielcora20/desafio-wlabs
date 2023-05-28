using Newtonsoft.Json;
using Wlabs.Domain.Entities;

namespace Wlabs.Infra.CrossCutting.Json
{
    public static class Serializers
    {
        public static string Serialize(this EntityBase entity)
        {
            return JsonConvert.SerializeObject(entity, Formatting.Indented);
        }
    }
}
