using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Backend.Infrastructure.Connection;
using Todo.Core.Entity;
using Todo.Core.Repository;

namespace Todo.Backend.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SqlConnectionFactory sqlFactory;

        public AccountRepository(SqlConnectionFactory sqlFactory)
        {
            this.sqlFactory = sqlFactory;
        }

        public async Task AddAccount(Account account, CancellationToken cancellationToken)
        {
            await sqlFactory.StoredProcedureAsync("[dbo].[AddAccount]", new { Login = account.Login, Password = account.Password, Email = account.Email }, cancellationToken);
        }

        public async Task<bool> CheckAccountEmailExists(string email, CancellationToken cancellationToken)
        {
            return await sqlFactory.StoredProcedureFirstAsync<bool>("[dbo].[CheckAccountEmailExists]", new { Email = email }, cancellationToken);
        }

        public async Task<bool> CheckAccountLoginExists(string login, CancellationToken cancellationToken)
        {
            return await sqlFactory.StoredProcedureFirstAsync<bool>("[dbo].[CheckAccountLoginExists]", new { Login = login }, cancellationToken);
        }

        public Task DeleteAccount(string login, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> GetAccount(string login, CancellationToken cancellationToken)
        {
            return await sqlFactory.StoredProcedureFirstAsync<Account>("[dbo].[GetAccount]", new { Login = login }, cancellationToken);
        }

        public Task<Account> GetAccountByEmail(string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountById(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
