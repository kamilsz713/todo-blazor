using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Query.Account.LoginQuery;

namespace Todo.Frontend.Core.State.Feature.AuthFeature.Action
{
     public class LoginRequestAction
    {
        public LoginQuery LoginQuery { get; set; }

        public LoginRequestAction(LoginQuery loginQuery)
        {
            LoginQuery = loginQuery;
        }
    }
}
