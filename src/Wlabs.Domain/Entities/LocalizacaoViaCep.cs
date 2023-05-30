using NetDevPack.Domain;
using Newtonsoft.Json;

namespace Wlabs.Domain.Entities
{
    public class LocalizacaoViaCep : EntityBase, IAggregateRoot
    {
        [JsonProperty(PropertyName = "cep")]
        public string Cep { get; private set; }

        [JsonProperty(PropertyName = "logradouro")]
        public string Logradouro { get; private set; }

        [JsonProperty(PropertyName = "complemento")]
        public string Complemento { get; private set; }

        [JsonProperty(PropertyName = "bairro")]
        public string Bairro { get; private set; }

        [JsonProperty(PropertyName = "localidade")]
        public string Localidade { get; private set; }

        [JsonProperty(PropertyName = "uf")]
        public string Uf { get; private set; }

        [JsonProperty(PropertyName = "ibge")]
        public string Ibge { get; private set; }

        [JsonProperty(PropertyName = "gia")]
        public string Gia { get; private set; }

        [JsonProperty(PropertyName = "ddd")]
        public string Ddd { get; private set; }

        [JsonProperty(PropertyName = "siafi")]
        public string Siafi { get; private set; }

        public LocalizacaoViaCep() {  }

        public LocalizacaoViaCep(string cep, string logradouro, string complemento, string bairro, string localidade, string uf, string ibge, string gia, string ddd, string siafi)
        {
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
            Ibge = ibge;
            Gia = gia;
            Ddd = ddd;
            Siafi = siafi;
        }
    }
}
