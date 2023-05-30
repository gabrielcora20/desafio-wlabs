using System.Text.Json.Serialization;

namespace Wlabs.Application.ViewModels
{
    public class JwtResponseViewModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
