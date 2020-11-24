using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Fluxor;
using Todo.Core.Service;
using Todo.Frontend.Core.State.Feature.AuthFeature.Action;

namespace Todo.Frontend.Core.State.Feature.AuthFeature.Effect
{
    public class LoginRequestEffect : Fluxor.Effect<LoginRequestAction>
    {
        private readonly IAccountService _accountService;

        public LoginRequestEffect(IAccountService accountService)
        {
            _accountService = accountService;
        }

        protected override async Task HandleAsync(LoginRequestAction action, IDispatcher dispatcher)
        {
            Console.WriteLine("FIRE");
            var token = await _accountService.Login(action.LoginQuery, CancellationToken.None);

            if(token.Result)
                dispatcher.Dispatch(new TokenLoadAction(token.Token));
            else
                dispatcher.Dispatch(new LoginFailedAction());
        }
    }
}
