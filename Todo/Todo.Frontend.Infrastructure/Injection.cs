using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Core.Service;
using Todo.Frontend.Infrastructure.Service;

namespace Todo.Frontend.Infrastructure
{
    public static class Injection
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAccountService, AccountService>();
        }
    }
}
