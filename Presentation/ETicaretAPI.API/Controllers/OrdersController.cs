using ETicaretAPI.Application.CQRS.Order.Command.Create;
using ETicaretAPI.Application.CQRS.Order.Query.GetAll;
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
        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrder([FromRoute]GetAllOrderQueryRequest getAllOrderQueryRequest)
        {
             List<GetAllOrderQueryResponse> getAllOrderQueryResponse = await _mediator.Send(getAllOrderQueryRequest);
            return Ok(getAllOrderQueryResponse);
        }


        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest createOrderCommandRequest)
        {
           CreateOrderCommandResponse createOrderCommandResponse= await _mediator.Send(createOrderCommandRequest);
           return Ok(createOrderCommandResponse);
        }

    }
}
