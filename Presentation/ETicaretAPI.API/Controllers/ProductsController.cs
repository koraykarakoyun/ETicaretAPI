
using ETicaretAPI.Application.CQRS.Product.Command.Add;
using ETicaretAPI.Application.CQRS.Product.Command.ChangeShowCase;
using ETicaretAPI.Application.CQRS.Product.Command.Delete;
using ETicaretAPI.Application.CQRS.Product.Command.ImageUpload;
using ETicaretAPI.Application.CQRS.Product.Command.InvoiceUpload;
using ETicaretAPI.Application.CQRS.Product.Command.UpdateById;
using ETicaretAPI.Application.CQRS.Product.Query.GetAll;
using ETicaretAPI.Application.CQRS.Product.Query.GetAllImage;
using ETicaretAPI.Application.CQRS.Product.Query.GetById;
using ETicaretAPI.Application.CQRS.Product.Query.GetImage;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        readonly IMediator _mediator;
        readonly IWebHostEnvironment _webHostEnvironment;


        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            List<GetAllProductQueryResponse> getAllProductQueryResponses = await _mediator.Send(getAllProductQueryRequest);
            return Ok(getAllProductQueryResponses);

        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse getByIdProductQueryResponse = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(getByIdProductQueryResponse);
        }


        [HttpPost("add")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Add(AddProductCommandRequest addProductCommandRequest)
        {
            AddProductCommandResponse addProductCommandResponse = await _mediator.Send(addProductCommandRequest);
            return Ok(addProductCommandResponse);

        }

        [HttpPut("update")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Update(UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse updateProductCommandResponse = await _mediator.Send(updateProductCommandRequest);
            return Ok(updateProductCommandResponse);


        }



        [HttpDelete("deletebyid/{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> DeletebyId(DeleteProductCommandRequest deleteProductCommandRequest)
        {
            DeleteProductCommandResponse deleteProductCommandResponse = await _mediator.Send(deleteProductCommandRequest);
            return Ok(deleteProductCommandResponse);

        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadProductCommandRequest ımageUploadProductCommandRequest)
        {

            ImageUploadProductCommandResponse ımageUploadProductCommandResponse = await _mediator.Send(ımageUploadProductCommandRequest);

            return Ok(ımageUploadProductCommandResponse);

        }


        [HttpGet("getimage/{ProductId}")]
        public async Task<IActionResult> GetImage([FromRoute] GetImageProductCommandRequest getImageProductCommandRequest)
        {


            List<GetImageProductCommandResponse> getImageProductCommandResponse = await _mediator.Send(getImageProductCommandRequest);

            return Ok(getImageProductCommandResponse);

        }



        [HttpGet("getallimage")]
        public async Task<IActionResult> getallimage([FromRoute] GetAllImageProductQueryRequest getAllImageProductQueryRequest)
        {

            List<GetAllImageProductQueryResponse> getAllImageProductQueryResponses = await _mediator.Send(getAllImageProductQueryRequest);

            return Ok(getAllImageProductQueryResponses);


        }

        [HttpPut("vitrin")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Vitrin(ChangeShowCaseProductCommandRequest changeShowCaseProductCommandRequest)
        {
            ChangeShowCaseProductCommandResponse changeShowCaseProductCommandResponse = await _mediator.Send(changeShowCaseProductCommandRequest);
            return Ok(changeShowCaseProductCommandResponse);
        }



    }
}
