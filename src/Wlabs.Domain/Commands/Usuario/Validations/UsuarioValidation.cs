using FluentValidation;

namespace Wlabs.Domain.Commands.Usuario.Validations
{
    public class UsuarioValidation<T> : AbstractValidator<T> where T : UsuarioCommand
    {
        protected void ValidateNome()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("Insira algo no campo nome");
        }

        protected void ValidateEmail()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Insira algo no campo e-mail")
                .EmailAddress().WithMessage("Insira um e-mail válido");
        }

        protected void ValidateSenha()
        {
            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("Insira algo no campo senha");
        }
    }
}
