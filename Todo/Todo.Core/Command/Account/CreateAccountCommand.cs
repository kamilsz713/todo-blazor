using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Core.Response.Account;

namespace Todo.Core.Command.Account
{
    public class CreateAccountCommand : IRequest<RegisteredAccountInfo>
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string RepeatPassword { get; set; }

        public string Email { get; set; }
    }
}
