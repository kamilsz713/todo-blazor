using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Core.Repository
{
    public interface IAccountRoleRepository
    {
        Task CreateRole(string userId, string roleId);
    }
}
