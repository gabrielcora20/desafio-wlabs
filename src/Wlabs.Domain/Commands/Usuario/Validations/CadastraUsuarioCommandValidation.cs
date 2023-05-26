namespace Wlabs.Domain.Commands.Usuario.Validations
{
    public class CadastraUsuarioCommandValidation : UsuarioValidation<CadastraUsuarioCommand>
    {
        public CadastraUsuarioCommandValidation()
        {
            ValidateNome();
            ValidateEmail();
            ValidateSenha();
        }
    }
}
