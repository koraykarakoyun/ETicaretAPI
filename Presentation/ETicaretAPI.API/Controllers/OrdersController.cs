using ETicaretAPI.Application.CQRS.Order.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class OrdersController : ControllerBase
    {

        IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest createOrderCommandRequest)
        {
           CreateOrderCommandResponse createOrderCommandResponse= await _mediator.Send(createOrderCommandRequest);
           return Ok(createOrderCommandResponse);
        }

    }
}
