using System.Reflection;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using Todo.Frontend.Core.State;

namespace Todo.Frontend.Core
{
    public static class Inject
    {
        public static void AddFluxorStore(this IServiceCollection services)
        {
            services.AddFluxor(options =>
            {
                options.ScanAssemblies(Assembly.GetExecutingAssembly());
                options.UseReduxDevTools();
            });

            services.AddScoped<StateFacade>();
        }
    }
}