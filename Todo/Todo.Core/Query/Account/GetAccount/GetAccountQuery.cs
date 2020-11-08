using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Core.Entity;

namespace Todo.Core.Query.Account.GetAccount
{
    public class GetAccountQuery : IRequest<Entity.Account>
    {
        public string Login { get; set; }
    }
}
