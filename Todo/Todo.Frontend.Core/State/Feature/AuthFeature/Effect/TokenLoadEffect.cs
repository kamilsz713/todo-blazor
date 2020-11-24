using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Todo.Frontend.Core.State.Feature.AuthFeature.Action;
using Todo.Frontend.Infrastructure.Auth;

namespace Todo.Frontend.Core.State.Feature.AuthFeature.Effect
{
    public class TokenLoadEffect : Fluxor.Effect<TokenLoadAction>
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly NavigationManager _navigationManager;

        public TokenLoadEffect(AuthenticationStateProvider authenticationStateProvider, NavigationManager navigationManager)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _navigationManager = navigationManager;
        }

        protected override async Task HandleAsync(TokenLoadAction action, IDispatcher dispatcher)
        {
            Console.WriteLine(action.Token);
            await (_authenticationStateProvider as JwtAuthenticationStateProvider).MarkAsAuthenticated(action.Token);

            _navigationManager.NavigateTo("/test");
        }
    }
}
