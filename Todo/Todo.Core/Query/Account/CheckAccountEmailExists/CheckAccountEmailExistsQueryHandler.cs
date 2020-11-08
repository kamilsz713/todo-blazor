using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Service;

namespace Todo.Core.Query.Account.CheckAccountEmailExists
{
    public class CheckAccountEmailExistsQueryHandler : IRequestHandler<CheckAccountEmailExistsQuery, bool>
    {
        private readonly IAccountService accountService;
        public CheckAccountEmailExistsQueryHandler(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public async Task<bool> Handle(CheckAccountEmailExistsQuery request, CancellationToken cancellationToken)
        {
            return await accountService.CheckIfEmailExists(request.Email, cancellationToken);
        }
    }
}
