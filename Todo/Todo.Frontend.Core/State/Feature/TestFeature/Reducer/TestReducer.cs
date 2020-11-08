using Fluxor;
using Todo.Frontend.Core.State.Feature.TestFeature.Action;
using Todo.Frontend.Core.State.Feature.TestFeature.State;

namespace Todo.Frontend.Core.State.Feature.TestFeature.Reducer
{
    public class TestReducer
    {
        [ReducerMethod]
        public static TestState ReduceTest(TestState state, TestAction action)
        {
            return new TestState
            {
                Value = "Test"
            };
        }
    }
}