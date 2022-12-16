using ETicaretAPI.Application.Const;
using ETicaretAPI.Application.CQRS.Category.Command.AddCategory;
using ETicaretAPI.Application.CQRS.Category.Command.DeleteCategory;
using ETicaretAPI.Application.CQRS.Category.Command.UpdateCategory;
using ETicaretAPI.Application.CQRS.Category.Query.GetAllCategories;
using ETicaretAPI.Application.CQRS.Category.Query.GetCategoryInProducts;
using ETicaretAPI.Application.CQRS.Product.Command.Add;
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
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CategoriesController : ControllerBase
    {

        IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        [AuthorizeDefinition(Menu = AttributeConst.Categories, ActionType = ActionType.Writing, Definiton = "Add Category")]
        public async Task<IActionResult> AddCategory(AddCategoryCommandRequest addCategoryCommandRequest)
        {
            AddCategoryCommandResponse addCategoryCommandResponse = await _mediator.Send(addCategoryCommandRequest);
            return Ok(addCategoryCommandResponse);

        }

        [HttpPut("[action]")]
        [AuthorizeDefinition(Menu = AttributeConst.Categories, ActionType = ActionType.Updateing, Definiton = "Update Category")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            UpdateCategoryCommandResponse updateCategoryCommandResponse = await _mediator.Send(updateCategoryCommandRequest);
            return Ok(updateCategoryCommandResponse);

        }

        [HttpDelete("[action]/{Id}")]
        [AuthorizeDefinition(Menu = AttributeConst.Categories, ActionType = ActionType.Deleting, Definiton = "Delete By Id Category")]
        public async Task<IActionResult> DeleteByIdCategory([FromRoute]DeleteByIdCategoryCommandRequest deleteByIdCategoryCommandRequest)
        {
            DeleteByIdCategoryCommandResponse deleteByIdCategoryCommandResponse = await _mediator.Send(deleteByIdCategoryCommandRequest);
            return Ok(deleteByIdCategoryCommandResponse);

        }

        [HttpGet("[action]")]
        [AuthorizeDefinition(Menu = AttributeConst.Categories, ActionType = ActionType.Reading, Definiton = "Get All Categories")]
        public async Task<IActionResult> GetAllCategories([FromRoute]GetAllCategoriesQueryRequest getAllCategoriesQueryRequest)
        {
            List<GetAllCategoriesQueryResponse> getAllCategoriesQueryResponse = await _mediator.Send(getAllCategoriesQueryRequest);
            return Ok(getAllCategoriesQueryResponse);

        }

        [HttpGet("[action]/{CategoryId}")]
        [AuthorizeDefinition(Menu = AttributeConst.Categories, ActionType = ActionType.Reading, Definiton = "Get Category In Products")]
        public async Task<IActionResult> GetCategoryInProducts([FromRoute]GetCategoryInProductsRequest getCategoryInProductsRequest)
        {
            List<GetCategoryInProductsResponse> getCategoryInProductsResponses = await _mediator.Send(getCategoryInProductsRequest);
            return Ok(getCategoryInProductsResponses);

        }





    }
}
