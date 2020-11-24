using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Frontend.Core.State.Feature.AuthFeature.State;

namespace Todo.Frontend.Core.State.Feature.AuthFeature
{
    class AuthFeature : Fluxor.Feature<AuthState>
    {
        public override string GetName() => "Auth";

        protected override AuthState GetInitialState() => new AuthState();
    }
}
