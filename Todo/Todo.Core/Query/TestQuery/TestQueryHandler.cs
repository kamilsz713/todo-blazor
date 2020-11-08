using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Todo.Core.Query.TestQuery
{
    public class TestQueryHandler: IRequestHandler<TestQuery, string>
    {
        public Task<string> Handle(TestQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => request.Value, cancellationToken);
        }
    }
}