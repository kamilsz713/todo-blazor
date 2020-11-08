using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Entity;
using Todo.Core.Service;

namespace Todo.Core.Query.Account.GetAccount
{
    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, Entity.Account>
    {
        private readonly IAccountService accountService;

        public GetAccountQueryHandler(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public async Task<Entity.Account> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            return await accountService.GetUserByLogin(request.Login, cancellationToken);
        }
    }
}
