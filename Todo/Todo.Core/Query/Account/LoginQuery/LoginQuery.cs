using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Core.Response.Account;

namespace Todo.Core.Query.Account.LoginQuery
{
    public class LoginQuery : IRequest<AuthInfo>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
