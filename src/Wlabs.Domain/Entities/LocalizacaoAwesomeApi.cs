using NetDevPack.Domain;

namespace Wlabs.Domain.Entities
{
    public class LocalizacaoAwesomeApi : EntityBase, IAggregateRoot
    {
        public string Cep { get; set; }
        public string AddressType { get; set; }
        public string AddressName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string City { get; set; }
        public string CityIbge { get; set; }
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