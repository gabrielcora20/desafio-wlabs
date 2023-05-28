using System.ComponentModel;

namespace Wlabs.Application.ViewModels
{
    public class LocalizacaoApiCepViewModel
    {
        [DisplayName("code")]
        public string Code { get; set; }

        [DisplayName("state")]
        public string State { get; set; }

        [DisplayName("city")]
        public string City { get; set; }

        [DisplayName("district")]
        public string District { get; set; }

        [DisplayName("address")]
        public string Address { get; set; }
    }
}
