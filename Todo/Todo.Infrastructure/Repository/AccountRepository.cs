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

        public async Task AddAccountAsync(Account account, CancellationToken cancellationToken)
        {
            await sqlFactory.StoredProcedureAsync("[dbo].[AddAccount]", new { Login = account.Login, Password = account.Password, Email = account.Email }, cancellationToken);
        }

        public async Task<bool> CheckAccountEmailExistsAsync(string email, CancellationToken cancellationToken)
        {
            return await sqlFactory.StoredProcedureFirstAsync<bool>("[dbo].[CheckAccountEmailExists]", new { Email = email }, cancellationToken);
        }

        public async Task<bool> CheckAccountLoginExistsAsync(string login, CancellationToken cancellationToken)
        {
            return await sqlFactory.StoredProcedureFirstAsync<bool>("[dbo].[CheckAccountLoginExists]", new { Login = login }, cancellationToken);
        }

        public async Task<Account> GetAccountAsync(string login, CancellationToken cancellationToken)
        {
            return await sqlFactory.StoredProcedureFirstAsync<Account>("[dbo].[GetAccount]", new { Login = login }, cancellationToken);
        }

        public async Task<string> GetAccountPasswordHashAsync(string login, CancellationToken cancellationToken)
        {
            return await sqlFactory.StoredProcedureFirstAsync<string>("[dbo].[GetAccountPasswordHash]", new { Login = login }, cancellationToken);
        }
    }
}
