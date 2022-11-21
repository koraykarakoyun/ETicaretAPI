using ETicaretAPI.Application.Const;
using ETicaretAPI.Application.CQRS.Basket.Command.Add;
using ETicaretAPI.Application.CQRS.Basket.Command.RemoveItemToBasket;
using ETicaretAPI.Application.CQRS.Basket.Command.UpdateBasketItem;
using ETicaretAPI.Application.CQRS.Basket.Query.GetBasketItem;
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
    public class BasketsController : ControllerBase
    {
        IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AuthorizeDefinition(Menu =AttributeConst.Baskets,ActionType =ActionType.Reading,Definiton ="Get Basket Item")]
        [HttpGet("getbasketitem")]
        public async Task<IActionResult> GetBasketItem([FromRoute] GetBasketItemQueryRequest getBasketItemQueryRequest)
        {

            List<GetBasketItemQueryResponse> getBasketItemQueryResponse=await _mediator.Send(getBasketItemQueryRequest);
            return Ok(getBasketItemQueryResponse);

        }


        [AuthorizeDefinition(Menu = AttributeConst.Baskets, ActionType = ActionType.Updateing, Definiton = "Update Basket Item")]
        [HttpPut("updatebasketitem")]
        public async Task<IActionResult> UpdateBasketItem(UpdateBasketItemCommandRequest updateBasketItemCommandRequest)
        {

            UpdateBasketItemCommandResponse updateBasketItemCommandResponse = await _mediator.Send(updateBasketItemCommandRequest);
            return Ok(updateBasketItemCommandResponse);

        }



        [AuthorizeDefinition(Menu = AttributeConst.Baskets, ActionType =ActionType.Writing, Definiton = "Add Basket Item")]
        [HttpPost("addbasketitem")]
        public async Task<IActionResult> AddBasketItem(AddItemToBasketCommandRequest addItemToBasketCommandRequest)
        {

            AddItemToBasketCommandResponse addItemToBasketCommandResponse= await _mediator.Send(addItemToBasketCommandRequest);
            return Ok(addItemToBasketCommandResponse);

        }


        [AuthorizeDefinition(Menu = AttributeConst.Baskets, ActionType =ActionType.Deleting, Definiton = "Delete Basket Item")]
        [HttpDelete("deletebasketitem")]
        public async Task<IActionResult> DeleteBasketItem(RemoveItemToBasketCommanRequest removeItemToBasketCommanRequest)
        {

            RemoveItemToBasketCommanResponse removeItemToBasketCommanResponse = await _mediator.Send(removeItemToBasketCommanRequest);
            return Ok(removeItemToBasketCommanResponse);

        }


    }
}
