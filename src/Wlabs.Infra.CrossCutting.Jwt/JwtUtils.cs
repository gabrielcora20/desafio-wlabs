using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

using Wlabs.Domain.Entities;
using Wlabs.Infra.CrossCutting.Jwt.Interfaces;

namespace Wlabs.Infra.CrossCutting.Jwt
{
    public class JwtUtils : IJwtUtils
    {
        private readonly IConfiguration _configuration;
        public JwtUtils(IConfiguration configuration)
        {
            _configuration = configuration;

            if (string.IsNullOrEmpty(_configuration["JwtConfiguration:secret"]))
                throw new InvalidCredentialException("O campo 'Secret' não foi configurado no AppSettings.json");
        }

        public string GenerateJwtToken(Usuario user)
        {
            Log.Information($"Executando o método {nameof(GenerateJwtToken)} na classe: {GetType().Name}");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtConfiguration:secret"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Issuer = _configuration["JwtConfiguration:uri"],
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
