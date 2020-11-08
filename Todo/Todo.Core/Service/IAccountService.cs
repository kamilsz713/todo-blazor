using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Command.Account;
using Todo.Core.Entity;
using Todo.Core.Response.Account;

namespace Todo.Core.Service
{
    public interface IAccountService
    {
        Task<Account> GetUserByLogin(string login, CancellationToken cancellationToken);
        Task<bool> CheckIfLoginExists(string login, CancellationToken cancellationToken);
        Task<bool> CheckIfEmailExists(string email, CancellationToken cancellationToken);
        Task<RegisteredAccountInfo> RegisterAccount(CreateAccountCommand account, CancellationToken cancellationToken);
    }
}
