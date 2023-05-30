using NetDevPack.Domain;
using Newtonsoft.Json;

namespace Wlabs.Domain.Entities
{
    public class LocalizacaoApiCep : EntityBase, IAggregateRoot
    {
        public string Code { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }
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