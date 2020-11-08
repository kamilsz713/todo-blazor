using FluentValidation;

namespace Todo.Core.Query.TestQuery
{
    public class TestQueryValidator : AbstractValidator<TestQuery>
    {
        public TestQueryValidator()
        {
            RuleFor(x => x.Value).NotEmpty();
        }
    }
}