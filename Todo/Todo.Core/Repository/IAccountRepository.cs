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
        Task<bool> CheckAccountEmailExists(string email, CancellationToken cancellationToken);

        Task<bool> CheckAccountLoginExists(string login, CancellationToken cancellationToken);

        Task<Account> GetAccount(string login, CancellationToken cancellationToken);

        Task<Account> GetAccountByEmail(string email, CancellationToken cancellationToken);

        Task<Account> GetAccountById(string id, CancellationToken cancellationToken);

        Task AddAccount(Account account, CancellationToken cancellationToken);

        Task DeleteAccount(string login, CancellationToken cancellationToken);
    }
}
