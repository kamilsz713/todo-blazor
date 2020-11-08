using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Core.Query.Account.CheckAccountLoginExists
{
    public class CheckAccountLoginExistsQueryValidator : AbstractValidator<CheckAccountLoginExistsQuery>
    {
        public CheckAccountLoginExistsQueryValidator()
        {
            RuleFor(x => x.Login).NotEmpty();
        }
    }
}
