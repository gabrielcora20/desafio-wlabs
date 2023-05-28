using NetDevPack.Domain;
using Newtonsoft.Json;

namespace Wlabs.Domain.Entities
{
    public class LocalizacaoApiCep : EntityBase, IAggregateRoot
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; private set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; private set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; private set; }

        [JsonProperty(PropertyName = "district")]
        public string District { get; private set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; private set; }

        public LocalizacaoApiCep() { }

        public LocalizacaoApiCep(string code, string state, string city, string district, string address)
        {
            Code = code;
            State = state;
            City = city;
            District = district;
            Address = address;
        }
    }
}