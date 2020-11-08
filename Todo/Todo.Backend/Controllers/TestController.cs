using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Core.Query.TestQuery;

namespace Todo.Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : Controller
    {

        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new TestQuery()));
        }
    }
}