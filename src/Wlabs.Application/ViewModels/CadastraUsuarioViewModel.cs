using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Wlabs.Application.ViewModels
{
    public class CadastraUsuarioViewModel
    {
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public virtual string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'E-mail' é obrigatório")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public virtual string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Senha' é obrigatório")]
        [EmailAddress]
        [DisplayName("Senha")]
        public virtual string Senha { get; set; }
    }
}
