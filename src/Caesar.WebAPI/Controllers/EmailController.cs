using Caesar.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Caesar.WebAPI.Controllers
{
    [Route("api/emails")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetEmails.Query();

            var phones = await _mediator.Send(query);

            return Ok(phones);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string phone)
        {
            var command = new CreateEmail.Command(phone);

            await _mediator.Send(command);

            return Ok();
        }
    }
}