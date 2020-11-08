using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Core.Query.Account.GetAccount
{
    public class GetAccountQueryValidator : AbstractValidator<GetAccountQuery>
    {
        public GetAccountQueryValidator()
        {
            RuleFor(x => x.Login).NotEmpty();
        }
    }
}
