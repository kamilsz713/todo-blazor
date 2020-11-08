using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Core.Query.Account.CheckAccountEmailExists;
using Todo.Core.Query.Account.CheckAccountLoginExists;

namespace Todo.Core.Command.Account
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator(IMediator mediator)
        {
            RuleFor(x => x.Login)
               .NotEmpty().WithMessage("Nie podano loginu")
               .MustAsync(async (x, cancellationToken) => !await mediator.Send(new CheckAccountLoginExistsQuery { Login = x }, cancellationToken)).WithMessage("Użytkownik o takim loginie istnieje");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Nie podano hasła");

            RuleFor(x => x.RepeatPassword)
                .NotEmpty().WithMessage("Nie podano powtórzonego hasła");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Nie podano adresu e-mail")
                .EmailAddress().WithMessage("Podano nieprawidłowy adres e-mail")
                .MustAsync(async (x, cancellationToken) => !await mediator.Send(new CheckAccountEmailExistsQuery { Email = x }, cancellationToken)).WithMessage("Użytkownik o takim adresie e-mail istnieje");

            RuleFor(x => x)
                .Must(x => x.Password == x.RepeatPassword).WithMessage("Podane hasła się różnią");
        }
    }
}
