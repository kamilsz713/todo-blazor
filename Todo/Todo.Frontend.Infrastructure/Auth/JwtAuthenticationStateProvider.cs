using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Blazored.LocalStorage;
using System.Security.Claims;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;

namespace Todo.Frontend.Infrastructure.Auth
{
    public class JwtAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly JwtParser jwtParser;
        private readonly HttpClient httpClient;
        private readonly ILogger<JwtAuthenticationStateProvider> logger;

        public JwtAuthenticationStateProvider(JwtParser jwtParser, HttpClient httpClient, ILogger<JwtAuthenticationStateProvider> logger)
        {
            this.jwtParser = jwtParser;
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var tokenExists = await jwtParser.TokenExistsAsync();

            Console.WriteLine("TOKEN: " + tokenExists);

            if (!tokenExists)
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            var token = await jwtParser.GetToken();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(await jwtParser.GetClaimsAsync(), "jwt")));
        }

        public async Task MarkAsAuthenticated(string token)
        {
            await jwtParser.SetToken(token);

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task Logout()
        {
            await jwtParser.DeleteToken();

            httpClient.DefaultRequestHeaders.Authorization = null;

            var task = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

            NotifyAuthenticationStateChanged(task);
        }
    }
}
