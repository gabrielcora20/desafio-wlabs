using NetDevPack.Domain;
using Newtonsoft.Json;

namespace Wlabs.Domain.Entities
{
    public class LocalizacaoViaCep : EntityBase, IAggregateRoot
    {
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Localidade { get; private set; }
        public string Uf { get; private set; }
        public string Ibge { get; private set; }
        public string Gia { get; private set; }
        public string Ddd { get; private set; }
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
