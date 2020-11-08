using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace Todo.Backend.Initial
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var fails = _validators
                .Select(x => x.Validate(request))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();

            if (fails.Any())
            {
                throw new ValidationException(fails);
            }

            return next();
        }
    }
}