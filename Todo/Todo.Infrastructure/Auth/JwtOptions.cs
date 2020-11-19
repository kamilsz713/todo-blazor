using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Backend.Infrastructure.Auth
{
    public class JwtOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly RsaSecurityKey rsaSecurityKey;

        public JwtOptions(RsaSecurityKey rsaSecurityKey)
        {
            this.rsaSecurityKey = rsaSecurityKey;
        }

        public void Configure(string name, JwtBearerOptions options)
        {
            if (name == JwtBearerDefaults.AuthenticationScheme)
            {
                options.IncludeErrorDetails = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = rsaSecurityKey,
                    ValidAudience = "https://localhost:4200",
                    ValidIssuer = "https://localhost:11000",
                    RequireSignedTokens = true,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true
                };
            }
        }

        public void Configure(JwtBearerOptions options)
        {
            Configure(JwtBearerDefaults.AuthenticationScheme, options);
        }
    }
}
