using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Entity;

namespace Todo.Core.Repository
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleById(string id, CancellationToken cancellationToken);

        Task<IEnumerable<Role>> GetRoles(CancellationToken cancellationToken);
    }
}
