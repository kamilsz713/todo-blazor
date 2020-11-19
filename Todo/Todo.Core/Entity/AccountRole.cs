using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Core.Entity
{
    public class AccountRole
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid RoleId { get; set; }
    }
}
