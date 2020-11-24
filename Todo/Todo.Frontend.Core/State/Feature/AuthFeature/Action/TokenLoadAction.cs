using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Frontend.Core.State.Feature.AuthFeature.Action
{
    public class TokenLoadAction
    {
        public string Token { get; set; }

        public TokenLoadAction(string token)
        {
            Token = token;
        }
    }
}
