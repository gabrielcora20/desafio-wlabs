using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Wlabs.Services.Core.Configurations
{
    public static class JwtAuthenticationConfig
    {
        public static void AddJwtAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var key = configuration["JwtConfiguration:secret"];
            var issuer = configuration["JwtConfiguration:uri"];

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateAudience = false,
                      ValidateIssuer = true,
                      ValidIssuer = issuer,
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key))
                  };

                  options.Events = new JwtBearerEvents
                  {
                      OnAuthenticationFailed = context =>
                      {
                          if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                          {
                              context.Response.Headers.Add("Token-Expired", "true");
                          }
                          return Task.CompletedTask;
                      }
                  };
              });
        }
    }
}
