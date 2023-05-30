using System.Text.Json.Serialization;

namespace Wlabs.Application.ViewModels
{
    public class LocalizacaoApiCepViewModel
    {
        [JsonPropertyName("cep")]
        public string Code { get; set; }

        [JsonPropertyName("estado")]
        public string State { get; set; }

        [JsonPropertyName("cidade")]
        public string City { get; set; }

        [JsonPropertyName("bairro")]
        public string District { get; set; }

        [JsonPropertyName("endereco")]
        public string Address { get; set; }
    }
}
