using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Response.Account;
using Todo.Core.Service;

namespace Todo.Core.Query.Account.LoginQuery
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthInfo>
    {
        private readonly IAccountService accountService;

        public LoginQueryHandler(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public async Task<AuthInfo> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return await accountService.Login(request, cancellationToken);
        }
    }
}
