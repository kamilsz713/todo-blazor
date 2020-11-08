using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Todo.Core
{
    public static class Injection
    {
        public static void AddCore(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddValidatorsFromAssembly(typeof(Injection).Assembly);
            serviceCollection.AddMediatR(typeof(Injection).Assembly);
        }
    }
}