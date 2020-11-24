using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Frontend.Core.State.Feature.AuthFeature.State
{
    public class AuthState
    {
        public bool WaitingForResult { get; set; }
        public bool Logged { get; set; }
        public string Token { get; set; }
    }
}
