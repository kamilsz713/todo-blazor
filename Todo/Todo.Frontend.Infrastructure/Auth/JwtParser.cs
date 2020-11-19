using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Todo.Frontend.Infrastructure.Auth
{
    public class JwtParser
    {
        private readonly ILocalStorageService localStorage;

        public JwtParser(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }

        public async ValueTask<IEnumerable<Claim>> GetClaimsAsync()
        {
            var claims = new List<Claim>();

            var jwt = await GetToken();
            var jsonBytes = ParseBase64WithoutPadding(jwt);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        public async ValueTask<string> GetToken()
        {
            return await localStorage.GetItemAsStringAsync("token");
        }

        public async Task DeleteToken()
        {
            await localStorage.RemoveItemAsync("token");
        }

        public async ValueTask<bool> TokenExistsAsync()
        {
            return await localStorage.ContainKeyAsync("token");
        }

        public async Task SetToken(string token)
        {
            await localStorage.SetItemAsync("token", token);
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
