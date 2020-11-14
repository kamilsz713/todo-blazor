using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Command.Account;
using Todo.Core.Entity;
using Todo.Core.Query.Account.LoginQuery;
using Todo.Core.Response.Account;
using Todo.Core.Service;

namespace Todo.Frontend.Infrastructure.Service
{
    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> logger;
        private readonly HttpClient httpClient;

        public AccountService(ILogger<AccountService> logger, HttpClient httpClient)
        {
            this.logger = logger;
            this.httpClient = httpClient;
        }

        public async Task<bool> CheckIfEmailExists(string email, CancellationToken cancellationToken)
        {
            return await httpClient.GetJsonAsync<bool>($"Account/CheckEmailExists/{email}");
        }

        public async Task<bool> CheckIfLoginExists(string login, CancellationToken cancellationToken)
        {
            return await httpClient.GetJsonAsync<bool>($"Account/CheckLoginExists/{login}");
        }

        public async Task<Account> GetUserByLogin(string login, CancellationToken cancellationToken)
        {
            logger.Log(LogLevel.Debug, "GetUserByLogin");
            throw new NotImplementedException();
        }

        public Task<AuthInfo> Login(LoginQuery loginQuery, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<RegisteredAccountInfo> RegisterAccount(CreateAccountCommand account, CancellationToken cancellationToken)
        {
            return await httpClient.PostJsonAsync<RegisteredAccountInfo>("Account", account);
        }
    }
}
