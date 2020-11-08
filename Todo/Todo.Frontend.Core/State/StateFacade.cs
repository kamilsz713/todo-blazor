using Fluxor;
using Microsoft.Extensions.Logging;
using Todo.Frontend.Core.State.Feature.TestFeature.Action;

namespace Todo.Frontend.Core.State
{
    public class StateFacade
    {
        private readonly ILogger<StateFacade> _logger;
        private readonly IDispatcher _dispatcher;

        public StateFacade(ILogger<StateFacade> logger, IDispatcher dispatcher) =>
            (_logger, _dispatcher) = (logger, dispatcher);

        public void LoadTest()
        {
            _logger.Log(LogLevel.Debug, "Load test");
            _dispatcher.Dispatch(new TestAction());
        }
    }
}