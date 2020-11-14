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
    public class RoleRepository : IRoleRepository
    {
        private readonly SqlConnectionFactory sqlFactory;

        public RoleRepository(SqlConnectionFactory sqlFactory)
        {
            this.sqlFactory = sqlFactory;
        }

        public Task<Role> GetRoleById(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetRoles(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
