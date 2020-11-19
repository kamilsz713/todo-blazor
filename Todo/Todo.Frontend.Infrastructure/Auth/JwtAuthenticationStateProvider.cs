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

namespace Todo.Frontend.Infrastructure.Auth
{
    public class JwtAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly JwtParser jwtParser;
        private readonly HttpClient httpClient;

        public JwtAuthenticationStateProvider(JwtParser jwtParser, HttpClient httpClient)
        {
            this.jwtParser = jwtParser;
            this.httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var tokenExists = await jwtParser.TokenExistsAsync();

            if (!tokenExists)
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            var token = await jwtParser.GetToken();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(await jwtParser.GetClaimsAsync(), "")));
        }

        public async Task MarkAsAuthenticated(string token)
        {
            await jwtParser.SetToken(token);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var task = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(await jwtParser.GetClaimsAsync(), ""))));

            NotifyAuthenticationStateChanged(task);
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
