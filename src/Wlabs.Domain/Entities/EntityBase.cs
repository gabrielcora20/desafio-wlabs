using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NetDevPack.Messaging;
using Newtonsoft.Json;
using Wlabs.Domain.Converter;

namespace Wlabs.Domain.Entities
{
    public abstract class EntityBase
    {
        private List<Event> _domainEvents;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [JsonIgnore]
        public IReadOnlyCollection<Event> DomainEvents => _domainEvents?.AsReadOnly();
        public ObjectId GetId() { return Id; }

        protected EntityBase()
        {
            Id = ObjectId.GenerateNewId();
        }

        public void AddDomainEvent(Event domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<Event>();
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(Event domainEvent)
        {
            _domainEvents?.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public override bool Equals(object obj)
        {
            EntityBase entity = obj as EntityBase;
            if ((object)this == entity)
            {
                return true;
            }

            if ((object)entity == null)
            {
                return false;
            }

            return Id.Equals(entity.Id);
        }

        public static bool operator ==(EntityBase a, EntityBase b)
        {
            if ((object)a == null && (object)b == null)
            {
                return true;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(EntityBase a, EntityBase b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() ^ 0x5D) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
