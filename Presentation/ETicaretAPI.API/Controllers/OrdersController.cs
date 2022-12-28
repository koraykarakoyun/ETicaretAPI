using ETicaretAPI.Application.Const;
using ETicaretAPI.Application.CQRS.Order.Command.CompleteOrder;
using ETicaretAPI.Application.CQRS.Order.Command.Create;
using ETicaretAPI.Application.CQRS.Order.Query.GetAll;
using ETicaretAPI.Application.CQRS.Order.Query.GetAllOrdersByUser;
using ETicaretAPI.Application.CQRS.Order.Query.GetByIdUserOrderDetail;
using ETicaretAPI.Application.CQRS.Order.Query.GetOrderDetailById;
using ETicaretAPI.Application.CustomAttributes;
using ETicaretAPI.Application.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class OrdersController : ControllerBase
    {

        IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AuthorizeDefinition(Menu = AttributeConst.Orders, ActionType =ActionType.Reading, Definiton = "Get All Orders")]
        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrder([FromRoute] GetAllOrderQueryRequest getAllOrderQueryRequest)
        {
            List<GetAllOrderQueryResponse> getAllOrderQueryResponse = await _mediator.Send(getAllOrderQueryRequest);
            return Ok(getAllOrderQueryResponse);
        }


        [AuthorizeDefinition(Menu = AttributeConst.Orders, ActionType = ActionType.Reading, Definiton = "Get Order Detail")]
        [HttpGet("GetOrderDetailById/{OrderId}")]
        public async Task<IActionResult> GetOrderDetailById([FromRoute] GetOrderDetailByIdQueryRequest getOrderDetailByIdQueryRequest)
        {
            GetOrderDetailByIdQueryResponse getOrderDetailByIdQueryResponse = await _mediator.Send(getOrderDetailByIdQueryRequest);
            return Ok(getOrderDetailByIdQueryResponse);
        }


        [AuthorizeDefinition(Menu = AttributeConst.Orders, ActionType = ActionType.Writing, Definiton = "Create Order")]
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest createOrderCommandRequest)
        {
            CreateOrderCommandResponse createOrderCommandResponse = await _mediator.Send(createOrderCommandRequest);
            return Ok(createOrderCommandResponse);
        }

        [AuthorizeDefinition(Menu = AttributeConst.Orders, ActionType = ActionType.Writing, Definiton = "Complete Order")]
        [HttpPost("CompleteOrder/{CompleteOrderId}")]
        public async Task<IActionResult> CompleteOrder([FromRoute]CompletedOrderCommandRequest completedOrderCommandRequest)
        {
            CompletedOrderCommandResponse completedOrderCommandResponse = await _mediator.Send(completedOrderCommandRequest);
            return Ok(completedOrderCommandResponse);
        }

        [AuthorizeDefinition(Menu = AttributeConst.Orders, ActionType = ActionType.Reading, Definiton = "Get All Orders By User")]
        [HttpGet("GetAllOrdersByUser")]
        public async Task<IActionResult> GetAllOrdersByUser([FromRoute] GetAllOrdersByUserQueryRequest getAllOrdersByUserQueryRequest)
        {
            GetAllOrdersByUserQueryResponse getAllOrdersByUserQueryResponses= await _mediator.Send(getAllOrdersByUserQueryRequest);
            return Ok(getAllOrdersByUserQueryResponses);
        }

        [AuthorizeDefinition(Menu = AttributeConst.Orders, ActionType = ActionType.Reading, Definiton = "Get By Id User Order Detail")]
        [HttpGet("GetByIdUserOrderDetail/{OrderCode}")]
        public async Task<IActionResult> GetByIdUserOrderDetail([FromRoute] GetByIdUserOrderDetailQueryRequest getByIdUserOrderDetailQueryRequest)
        {
            GetByIdUserOrderDetailQueryResponse getByIdUserOrderDetailQueryResponse = await _mediator.Send(getByIdUserOrderDetailQueryRequest);
            return Ok(getByIdUserOrderDetailQueryResponse);
        }

    }
}
