using Wlabs.Domain.Entities;

namespace Wlabs.Infra.CrossCutting.Jwt.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(Usuario user);
    }
}
