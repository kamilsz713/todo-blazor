using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluxor;
using Todo.Frontend.Core.State.Feature.AuthFeature.Action;
using Todo.Frontend.Core.State.Feature.AuthFeature.State;

namespace Todo.Frontend.Core.State.Feature.AuthFeature.Reducer
{
    public class AuthReducer
    {
        [ReducerMethod]
        public static AuthState ReduceLoginRequestAction(AuthState state, LoginRequestAction loginRequestAction)
        {
            return new AuthState
            {
                WaitingForResult = true,
                Logged = false,
                Token = ""
            };
        }

        [ReducerMethod]
        public static AuthState ReduceLoginFailedAction(AuthState state, LoginFailedAction login)
        {
            return new AuthState
            {
                WaitingForResult = false,
                Logged = false,
                Token = ""
            };
        }

        [ReducerMethod]
        public static AuthState ReduceTokenLoadAction(AuthState state, TokenLoadAction token)
        {
            return new AuthState
            {
                WaitingForResult = false,
                Logged = true,
                Token = token.Token
            };
        }
    }
}
