using Fluxor.Blazor.Web.Components;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Core.Command.Account;
using Todo.Core.Request.Account;

namespace Todo.Frontend.Components.Register
{
    public partial class RegisterComponent : FluxorLayout
    {
        private CreateAccountCommand form = new CreateAccountCommand();

        public async Task Register()
        {
            var result = await mediator.Send(form);

            Logger.Log(LogLevel.Debug, JsonConvert.SerializeObject(result));
        }
    }
}
