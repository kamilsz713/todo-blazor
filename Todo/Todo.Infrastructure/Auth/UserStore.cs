using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Entity;
using Todo.Core.Repository;

namespace Todo.Backend.Infrastructure.Auth
{
    public class UserStore : IUserStore<Account>, IUserEmailStore<Account>, IUserPasswordStore<Account>, IUserRoleStore<Account>, IUserLoginStore<Account>
    {
        private readonly IPasswordHasher<Account> passwordHasher;
        private readonly IAccountRepository accountRepository;

        public UserStore(IPasswordHasher<Account> passwordHasher, IAccountRepository accountRepository)
        {
            this.passwordHasher = passwordHasher;
            this.accountRepository = accountRepository;
        }

        public async Task AddLoginAsync(Account user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            user.Login = login.ProviderKey;
        }

        public Task AddToRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateAsync(Account user, CancellationToken cancellationToken)
        {
            user.Password = passwordHasher.HashPassword(user, user.Password);

            await accountRepository.AddAccount(user, cancellationToken);

            var res = new IdentityResult();

            return res;
        }

        public async Task<IdentityResult> DeleteAsync(Account user, CancellationToken cancellationToken)
        {
            await accountRepository.DeleteAccount(user.Login, cancellationToken);

            return IdentityResult.Success;

        }

        public void Dispose()
        {

        }

        public async Task<Account> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return await accountRepository.GetAccountByEmail(normalizedEmail, cancellationToken);
        }

        public async Task<Account> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await accountRepository.GetAccountById(userId, cancellationToken);
        }

        public async Task<Account> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            return await accountRepository.GetAccount(providerKey, cancellationToken);
        }

        public async Task<Account> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return await accountRepository.GetAccount(normalizedUserName, cancellationToken);
        }

        public async Task<string> GetEmailAsync(Account user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.Email);
        }

        public async Task<bool> GetEmailConfirmedAsync(Account user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(true);
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(Account user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<UserLoginInfo> { new UserLoginInfo("", user.Login, user.Login) });
        }

        public async Task<string> GetNormalizedEmailAsync(Account user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.Email.ToUpper());
        }

        public async Task<string> GetNormalizedUserNameAsync(Account user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.Login.ToUpper());
        }

        public async Task<string> GetPasswordHashAsync(Account user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.Password);
        }

        public Task<IList<string>> GetRolesAsync(Account user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetUserIdAsync(Account user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.Id.ToString());
        }

        public async Task<string> GetUserNameAsync(Account user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.Login);
        }

        public Task<IList<Account>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> HasPasswordAsync(Account user, CancellationToken cancellationToken)
        {
            return true;
        }

        public Task<bool> IsInRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(Account user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(Account user, string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(Account user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task SetNormalizedEmailAsync(Account user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.Email = normalizedEmail;
        }

        public async Task SetNormalizedUserNameAsync(Account user, string normalizedName, CancellationToken cancellationToken)
        {
            user.Login = normalizedName;
        }

        public Task SetPasswordHashAsync(Account user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(Account user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(Account user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
