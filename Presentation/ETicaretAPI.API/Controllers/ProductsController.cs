
using ETicaretAPI.Application.CQRS.Product.Command.Add;
using ETicaretAPI.Application.CQRS.Product.Command.Delete;
using ETicaretAPI.Application.CQRS.Product.Command.UpdateById;
using ETicaretAPI.Application.CQRS.Product.Query.GetAll;
using ETicaretAPI.Application.CQRS.Product.Query.GetById;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        readonly IMediator _mediator;


        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IMediator mediator)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            List<GetAllProductQueryResponse> getAllProductQueryResponses = await _mediator.Send(getAllProductQueryRequest);
            return Ok(getAllProductQueryResponses);

        }
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse getByIdProductQueryResponse = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(getByIdProductQueryResponse);
        }

        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpPost("add")]
        public async Task<IActionResult> Add(AddProductCommandRequest addProductCommandRequest)
        {
            AddProductCommandResponse addProductCommandResponse = await _mediator.Send(addProductCommandRequest);
            return Ok(addProductCommandResponse);

        }

        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse updateProductCommandResponse= await _mediator.Send(updateProductCommandRequest);
            return Ok(updateProductCommandResponse);
            

        }



        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpDelete("DeletebyId/{id}")]
        public async Task<IActionResult> DeletebyId(DeleteProductCommandRequest deleteProductCommandRequest)
        {
            DeleteProductCommandResponse deleteProductCommandResponse= await _mediator.Send(deleteProductCommandRequest);
            return Ok(deleteProductCommandResponse);

        }

    }
}
