using System;
using System.Collections.Generic;
using System.Text;
using Todo.Core.Command.Account;
using Todo.Core.Request.Account;

namespace Todo.Backend.Infrastructure.Profile.Account
{
    public class AccountProfile : AutoMapper.Profile
    {
        public AccountProfile()
        {
            CreateMap<RegisterFormRequest, CreateAccountCommand>();
        }
    }
}
