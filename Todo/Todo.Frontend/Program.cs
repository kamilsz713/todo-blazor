using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Todo.Core;
using Todo.Frontend.Core;
using Todo.Frontend.Infrastructure;
using Todo.Frontend.Infrastructure.Auth;

namespace Todo.Frontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });
            builder.Services.AddAuthorizationCore();
            builder.Services.AddFluxorStore();
            builder.Services.AddCore();
            builder.Services.AddInfrastructure();
            builder.Services.AddOptions();
            await builder.Build().RunAsync();
        }
    }
}