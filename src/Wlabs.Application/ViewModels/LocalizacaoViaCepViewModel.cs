using System.ComponentModel;

namespace Wlabs.Application.ViewModels
{
    public class LocalizacaoViaCepViewModel
    {
        [DisplayName("cep")]
        public string Cep { get; set; }

        [DisplayName("logradouro")]
        public string Logradouro { get; set; }

        [DisplayName("complementos")]
        public string Complemento { get; set; }

        [DisplayName("bairro")]
        public string Bairro { get; set; }

        [DisplayName("localidade")]
        public string Localidade { get; set; }

        [DisplayName("uf")]
        public string Uf { get; set; }

        [DisplayName("ibge")]
        public string Ibge { get; set; }

        [DisplayName("gia")]
        public string Gia { get; set; }

        [DisplayName("ddd")]
        public string Ddd { get; set; }

        [DisplayName("siafi")]
        public string Siafi { get; set; }
    }
}
