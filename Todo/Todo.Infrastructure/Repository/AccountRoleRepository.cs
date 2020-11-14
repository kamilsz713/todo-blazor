using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Backend.Infrastructure.Connection;
using Todo.Core.Repository;

namespace Todo.Backend.Infrastructure.Repository
{
    public class AccountRoleRepository : IAccountRoleRepository
    {
        private readonly SqlConnectionFactory sqlFactory;

        public AccountRoleRepository(SqlConnectionFactory sqlFactory)
        {
            this.sqlFactory = sqlFactory;
        }

        public Task CreateRole(string userId, string roleId)
        {
            throw new NotImplementedException();
        }
    }
}
