using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Core.Query.Account.LoginQuery
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
