using Caesar.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Caesar.WebAPI.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetServices.Query();

            var todos = await _mediator.Send(query);

            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetServiceById.Query(id);

            var todo = await _mediator.Send(query);

            if (todo is not null)
            {
                return Ok(todo);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateService.Command command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}