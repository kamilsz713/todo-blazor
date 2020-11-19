using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Backend.Infrastructure.Auth;
using Todo.Backend.Infrastructure.Connection;
using Todo.Backend.Infrastructure.Repository;
using Todo.Backend.Infrastructure.Service;
using Todo.Core.Entity;
using Todo.Core.Repository;
using Todo.Core.Service;

namespace Todo.Backend.Infrastructure
{
    public static class Injection
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAccountService, AccountService>();
            serviceCollection.AddTransient<IAccountRoleRepository, AccountRoleRepository>();
            serviceCollection.AddTransient<IRoleRepository, RoleRepository>();
            serviceCollection.AddTransient<IAccountRepository, AccountRepository>();
            serviceCollection.AddTransient<JwtProvider>();

            serviceCollection.AddSqlFactory(con => con.GetConnectionString("Database"));

            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer();

            serviceCollection.ConfigureOptions<JwtOptions>();

        }
    }
}
