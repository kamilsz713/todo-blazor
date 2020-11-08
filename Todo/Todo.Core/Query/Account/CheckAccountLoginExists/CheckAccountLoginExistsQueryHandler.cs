using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Service;

namespace Todo.Core.Query.Account.CheckAccountLoginExists
{
    public class CheckAccountLoginExistsQueryHandler : IRequestHandler<CheckAccountLoginExistsQuery, bool>
    {
        private readonly IAccountService accountService;
        public CheckAccountLoginExistsQueryHandler(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public async Task<bool> Handle(CheckAccountLoginExistsQuery request, CancellationToken cancellationToken)
        {
            return await accountService.CheckIfLoginExists(request.Login, cancellationToken);
        }
    }
}
