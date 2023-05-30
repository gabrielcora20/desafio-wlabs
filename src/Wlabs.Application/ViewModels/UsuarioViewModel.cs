using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Wlabs.Application.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'E-mail' é obrigatório")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Senha' é obrigatório")]
        [DisplayName("Senha")]
        public string Senha { get; set; }
    }
}
