using MongoDB.Bson;
using Newtonsoft.Json;

namespace Wlabs.Domain.Converter
{
    public class ObjectIdConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(CanConvert(objectType))
                return ObjectId.Parse(reader.Value?.ToString());
            throw new NotSupportedException("O campo não pôde ser convertido para ObjectId");
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ObjectId).IsAssignableFrom(objectType);
        }
    }
}
