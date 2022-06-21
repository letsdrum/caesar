using Caesar.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Caesar.WebAPI.Controllers
{
    [Route("api/phones")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhoneController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetPhones.Query();

            var phones = await _mediator.Send(query);

            return Ok(phones);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string phone)
        {
            var command = new CreatePhone.Command(phone);

            await _mediator.Send(command);

            return Ok();
        }
    }
}