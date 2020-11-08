using Todo.Frontend.Core.State.Feature.TestFeature.State;

namespace Todo.Frontend.Core.State.Feature.TestFeature
{
    public class TestFeature : Fluxor.Feature<TestState>
    {
        public override string GetName() => "Test";

        protected override TestState GetInitialState() => new TestState();
    }
}