using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Backend.Infrastructure.Auth;
using Todo.Core.Command.Account;
using Todo.Core.Entity;
using Todo.Core.Query.Account.LoginQuery;
using Todo.Core.Repository;
using Todo.Core.Response.Account;
using Todo.Core.Service;

namespace Todo.Backend.Infrastructure.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountRoleRepository accountRoleRepository;
        private readonly IRoleRepository roleRepository;

        public AccountService(IAccountRepository accountRepository, IAccountRoleRepository accountRoleRepository, IRoleRepository roleRepository)
        {
            this.accountRepository = accountRepository;
            this.accountRoleRepository = accountRoleRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<bool> CheckIfEmailExists(string email, CancellationToken cancellationToken)
        {
            return await accountRepository.CheckAccountEmailExistsAsync(email, cancellationToken);
        }

        public async Task<bool> CheckIfLoginExists(string login, CancellationToken cancellationToken)
        {
            return await accountRepository.CheckAccountLoginExistsAsync(login, cancellationToken);
        }

        public async Task<Account> GetUserByLogin(string login, CancellationToken cancellationToken)
        {
            return await accountRepository.GetAccountAsync(login, cancellationToken);
        }

        public async Task<AuthInfo> Login(LoginQuery loginQuery, CancellationToken cancellationToken)
        {

            return null;
        }

        public async Task<RegisteredAccountInfo> RegisterAccount(CreateAccountCommand account, CancellationToken cancellationToken)
        {
            var user = new Account
            {
                Login = account.Login,
                Email = account.Email,
                Password = PasswordHasher.HashPassword(account.Password)
            };

            await accountRepository.AddAccountAsync(user, cancellationToken);

            return new RegisteredAccountInfo
            {
                IsCreated = true
            };
        }
    }
}
