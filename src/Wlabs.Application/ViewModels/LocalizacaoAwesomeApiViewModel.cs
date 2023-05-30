using System.Text.Json.Serialization;

namespace Wlabs.Application.ViewModels
{
    public class LocalizacaoAwesomeApiViewModel
    {
        [JsonPropertyName("cep")]
        public string Cep { get; set; }

        [JsonPropertyName("tipo_endereco")]
        public string AddressType { get; set; }

        [JsonPropertyName("descricao_endereco")]
        public string AddressName { get; set; }

        [JsonPropertyName("endereco")]
        public string Address { get; set; }

        [JsonPropertyName("estado")]
        public string State { get; set; }

        [JsonPropertyName("bairro")]
        public string District { get; set; }

        [JsonPropertyName("latitude")]
        public string Lat { get; set; }

        [JsonPropertyName("longitude")]
        public string Lng { get; set; }

        [JsonPropertyName("cidade")]
        public string City { get; set; }

        [JsonPropertyName("cidade_ibge")]
        public string CityIbge { get; set; }

        [JsonPropertyName("ddd")]
        public string Ddd { get; set; }
    }
}
