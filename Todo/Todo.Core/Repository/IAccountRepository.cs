using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Entity;

namespace Todo.Core.Repository
{
    public interface IAccountRepository
    {
        Task<bool> CheckAccountEmailExistsAsync(string email, CancellationToken cancellationToken);

        Task<bool> CheckAccountLoginExistsAsync(string login, CancellationToken cancellationToken);

        Task<Account> GetAccountAsync(string login, CancellationToken cancellationToken);

        Task AddAccountAsync(Account account, CancellationToken cancellationToken);

        Task<string> GetAccountPasswordHashAsync(string login, CancellationToken cancellationToken);
    }
}
