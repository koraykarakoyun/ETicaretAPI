
using ETicaretAPI.Application.CQRS.Product.Command.Add;
using ETicaretAPI.Application.CQRS.Product.Command.Delete;
using ETicaretAPI.Application.CQRS.Product.Command.UpdateById;
using ETicaretAPI.Application.CQRS.Product.Query.GetAll;
using ETicaretAPI.Application.CQRS.Product.Query.GetById;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModel;
using ETicaretAPI.Domain.Entities;
using MediatR;
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
        public async Task<IActionResult> GetAll(GetAllProductQueryRequest getAllProductQueryRequest)
        {
            List<GetAllProductQueryResponse> getAllProductQueryResponses = await _mediator.Send(getAllProductQueryRequest);
            return Ok(getAllProductQueryResponses);

        }
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse getByIdProductQueryResponse = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(getByIdProductQueryResponse);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddProductCommandRequest addProductCommandRequest)
        {
            AddProductCommandResponse addProductCommandResponse = await _mediator.Send(addProductCommandRequest);
            return Ok(addProductCommandResponse);

        }


        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse updateProductCommandResponse= await _mediator.Send(updateProductCommandRequest);
            return Ok(updateProductCommandResponse);
            

        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeletebyId(DeleteProductCommandRequest deleteProductCommandRequest)
        {
            DeleteProductCommandResponse deleteProductCommandResponse= await _mediator.Send(deleteProductCommandRequest);
            return Ok(deleteProductCommandResponse);

        }

    }
}
