using System.ComponentModel.DataAnnotations;
using Wlabs.Domain.Commands.Usuario.Validations;

namespace Wlabs.Domain.Commands.Usuario
{
    public class CadastraUsuarioCommand: UsuarioCommand
    {
        public CadastraUsuarioCommand(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public override bool IsValid()
        {
            ValidationResult = new CadastraUsuarioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
