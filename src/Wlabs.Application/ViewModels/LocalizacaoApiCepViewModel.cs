using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Wlabs.Application.ViewModels
{
    public class LocalizacaoApiCepViewModel
    {
        [JsonPropertyName("cep")]
        [DisplayName("cep")]
        public string Code { get; set; }

        [JsonPropertyName("estado")]
        [DisplayName("estado")]
        public string State { get; set; }

        [JsonPropertyName("cidade")]
        [DisplayName("cidade")]
        public string City { get; set; }

        [JsonPropertyName("bairro")]
        [DisplayName("bairro")]
        public string District { get; set; }

        [JsonPropertyName("logradouro")]
        [DisplayName("logradouro")]
        public string Address { get; set; }
    }
}
