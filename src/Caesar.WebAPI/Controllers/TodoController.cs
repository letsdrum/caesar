using Caesar.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Caesar.WebAPI.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetTodos.Query();

            var todos = await _mediator.Send(query);

            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetTodoById.Query(id);

            var todo = await _mediator.Send(query);

            if (todo is not null)
            {
                return Ok(todo);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var query = new DeletedTodoById.Command(id);

            await _mediator.Send(query);

            return Ok();
        }
    }
}