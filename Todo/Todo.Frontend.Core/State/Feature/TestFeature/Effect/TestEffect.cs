using System.Threading.Tasks;
using Fluxor;
using Microsoft.Extensions.Logging;
using Todo.Frontend.Core.State.Feature.TestFeature.Action;

namespace Todo.Frontend.Core.State.Feature.TestFeature.Effect
{
    public class TestEffect : Fluxor.Effect<TestAction>
    {
        private readonly ILogger<TestAction> _logger;

        public TestEffect(ILogger<TestAction> logger) =>
            _logger = logger;
        
        protected override async Task HandleAsync(TestAction action, IDispatcher dispatcher)
        {
            _logger.Log(LogLevel.Debug, "Effect");
            
        }
    }
}