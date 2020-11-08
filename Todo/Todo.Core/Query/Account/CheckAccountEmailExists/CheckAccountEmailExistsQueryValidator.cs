using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Core.Query.Account.CheckAccountEmailExists
{
    public class CheckAccountEmailExistsQueryValidator : AbstractValidator<CheckAccountEmailExistsQuery>
    {
        public CheckAccountEmailExistsQueryValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
