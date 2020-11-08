using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Command.Account;
using Todo.Core.Entity;
using Todo.Core.Repository;
using Todo.Core.Response.Account;
using Todo.Core.Service;

namespace Todo.Backend.Infrastructure.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly UserManager<Account> userManager;

        public AccountService(IAccountRepository accountRepository, UserManager<Account> userManager)
        {
            this.userManager = userManager;
            this.accountRepository = accountRepository;
        }

        public async Task<bool> CheckIfEmailExists(string email, CancellationToken cancellationToken)
        {
            return (await userManager.FindByEmailAsync(email)) != null;
            return await accountRepository.CheckAccountEmailExists(email, cancellationToken);
        }

        public async Task<bool> CheckIfLoginExists(string login, CancellationToken cancellationToken)
        {
            return (await userManager.FindByNameAsync(login)) != null;
            return await accountRepository.CheckAccountLoginExists(login, cancellationToken);
        }

        public async Task<Account> GetUserByLogin(string login, CancellationToken cancellationToken)
        {
            return await userManager.FindByNameAsync(login);
        }

        public async Task<RegisteredAccountInfo> RegisterAccount(CreateAccountCommand account, CancellationToken cancellationToken)
        {
            await userManager.CreateAsync(new Account
            {
                Login = account.Login,
                Password = account.Password,
                Email = account.Email
            });

            return new RegisteredAccountInfo
            {
                IsCreated = true
            };
        }
    }
}
