using MongoDB.Bson.Serialization;
using Wlabs.Domain.Entities;

namespace Wlabs.Infra.Data.Mappings
{
    public class EntityBaseMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<EntityBase>(map =>
            {
                map.MapIdMember(x => x.Id);
            });
        }
    }
}
