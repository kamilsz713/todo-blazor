using System.Net.Http;
using System.Reflection;
using Fluxor;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Todo.Core;
using Todo.Frontend.Core;
using Todo.Frontend.Infrastructure;

namespace Todo.Frontend
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddFluxorStore();
            services.AddSingleton(new HttpClient { BaseAddress = new System.Uri("http://localhost:5000/") });
            services.AddCore();
            services.AddInfrastructure();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}