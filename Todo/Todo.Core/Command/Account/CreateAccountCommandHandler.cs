using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Response.Account;
using Todo.Core.Service;

namespace Todo.Core.Command.Account
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, RegisteredAccountInfo>
    {
        private readonly IAccountService accountService;

        public CreateAccountCommandHandler(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public async Task<RegisteredAccountInfo> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            return await accountService.RegisterAccount(request, cancellationToken);
        }
    }
}
