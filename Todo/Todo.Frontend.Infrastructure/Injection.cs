using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Core.Service;
using Todo.Frontend.Infrastructure.Auth;
using Todo.Frontend.Infrastructure.Service;

namespace Todo.Frontend.Infrastructure
{
    public static class Injection
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAccountService, AccountService>();
            serviceCollection.AddTransient<JwtParser>();
            serviceCollection.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();

            serviceCollection.AddBlazoredLocalStorage();
        }
    }
}
