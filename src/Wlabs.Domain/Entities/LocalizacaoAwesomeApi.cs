using NetDevPack.Domain;
using Newtonsoft.Json;

namespace Wlabs.Domain.Entities
{
    public class LocalizacaoAwesomeApi : EntityBase, IAggregateRoot
    {
        [JsonProperty(PropertyName = "cep")]
        public string Cep { get; set; }

        [JsonProperty(PropertyName = "address_type")]
        public string AddressType { get; set; }

        [JsonProperty(PropertyName = "address_name")]
        public string AddressName { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "district")]
        public string District { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public string Lat { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public string Lng { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "city_ibge")]
        public string CityIbge { get; set; }

        [JsonProperty(PropertyName = "ddd")]
        public string Ddd { get; set; }

        public LocalizacaoAwesomeApi() { }
        public LocalizacaoAwesomeApi(string cep, string addressType, string addressName, string address, string state, string district, string lat, string lng, string city, string cityIbge, string ddd)
        {
            Cep = cep;
            AddressType = addressType;
            AddressName = addressName;
            Address = address;
            State = state;
            District = district;
            Lat = lat;
            Lng = lng;
            City = city;
            CityIbge = cityIbge;
            Ddd = ddd;
        }
    }
}