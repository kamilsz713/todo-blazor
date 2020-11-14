using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Todo.Core;
using Todo.Frontend.Core;
using Todo.Frontend.Infrastructure;

namespace Todo.Frontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddFluxorStore();
            builder.Services.AddCore();
            builder.Services.AddInfrastructure();

            await builder.Build().RunAsync();
        }
    }
}