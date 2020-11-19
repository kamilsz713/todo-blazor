using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Entity;

namespace Todo.Backend.Infrastructure.Auth
{
    public class JwtProvider
    {

        public JwtToken GenerateToken(Account account)
        {
            using RSA rsa = RSA.Create();

            rsa.ImportRSAPrivateKey(
                source: Convert.FromBase64String(File.ReadAllText("private.key")),
                bytesRead: out int _);

            var signingCredentials = new SigningCredentials(
                key: new RsaSecurityKey(rsa),
                algorithm: SecurityAlgorithms.RsaSha256
            )
            {
                CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
            };

            DateTime jwtDate = DateTime.Now;

            var jwt = new JwtSecurityToken(
                audience: "https://localhost:4200",
                issuer: "https://localhost:11000",
                claims: GetUserClaims(account),
                notBefore: jwtDate,
                expires: jwtDate.AddMinutes(10),
                signingCredentials: signingCredentials
            );

            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtToken(token, new DateTimeOffset(jwtDate).ToUnixTimeMilliseconds());
        }

        private Claim[] GetUserClaims(Account account)
        {
            return new Claim[] 
            {
                new Claim(ClaimTypes.NameIdentifier, "a")
            };
        }
    }
}
