using MediatR;

namespace Todo.Core.Query.TestQuery
{
    public class TestQuery : IRequest<string>
    {
        public string Value { get; set; }
    }
}