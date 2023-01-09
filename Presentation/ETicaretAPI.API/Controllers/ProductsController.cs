
using ETicaretAPI.Application.Const;
using ETicaretAPI.Application.CQRS.Product.Command.Add;
using ETicaretAPI.Application.CQRS.Product.Command.ChangeShowCase;
using ETicaretAPI.Application.CQRS.Product.Command.Delete;
using ETicaretAPI.Application.CQRS.Product.Command.ImageUpload;
using ETicaretAPI.Application.CQRS.Product.Command.InvoiceUpload;
using ETicaretAPI.Application.CQRS.Product.Command.UpdateById;
using ETicaretAPI.Application.CQRS.Product.Query.GetAll;
using ETicaretAPI.Application.CQRS.Product.Query.GetAllImage;
using ETicaretAPI.Application.CQRS.Product.Query.GetById;
using ETicaretAPI.Application.CQRS.Product.Query.GetByIdProductAllImages;
using ETicaretAPI.Application.CQRS.Product.Query.GetImage;
using ETicaretAPI.Application.CQRS.Product.Query.SearchProducts;
using ETicaretAPI.Application.CQRS.Product.Query.SortAllProducts;
using ETicaretAPI.Application.CustomAttributes;
using ETicaretAPI.Application.Enums;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mail;

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
        [AuthorizeDefinition(Menu = AttributeConst.Products, ActionType = ActionType.Reading, Definiton = "Get All Product")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            List<GetAllProductQueryResponse> getAllProductQueryResponses = await _mediator.Send(getAllProductQueryRequest);
            return Ok(getAllProductQueryResponses);

        }

        [HttpGet("getbyid/{id}")]
        [AuthorizeDefinition(Menu = AttributeConst.Products, ActionType = ActionType.Reading, Definiton = "Get By Id Product")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse getByIdProductQueryResponse = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(getByIdProductQueryResponse);
        }


        [HttpGet("SearchProducts/{word}")]
        [AuthorizeDefinition(Menu = AttributeConst.Products, ActionType = ActionType.Reading, Definiton = "SearchProducts")]
        public async Task<IActionResult> SearchProducts([FromRoute] SearchProductsQueryRequest searchProductsQueryRequest)
        {
            List<SearchProductsQueryResponse> searchProductsQueryResponse = await _mediator.Send(searchProductsQueryRequest);
            return Ok(searchProductsQueryResponse);
        }



        [HttpPost("add")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AttributeConst.Products, ActionType = ActionType.Writing, Definiton = "Add Product")]
        public async Task<IActionResult> Add(AddProductCommandRequest addProductCommandRequest)
        {
            AddProductCommandResponse addProductCommandResponse = await _mediator.Send(addProductCommandRequest);
            return Ok(addProductCommandResponse);

        }

        [HttpPut("update")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AttributeConst.Products, ActionType = ActionType.Updateing, Definiton = "Update Product")]
        public async Task<IActionResult> Update(UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse updateProductCommandResponse = await _mediator.Send(updateProductCommandRequest);
            return Ok(updateProductCommandResponse);


        }



        [HttpDelete("deletebyid/{id}")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AttributeConst.Products, ActionType = ActionType.Deleting, Definiton = "Delete By Id Product")]
        public async Task<IActionResult> DeletebyId([FromRoute] DeleteProductCommandRequest deleteProductCommandRequest)
        {
            DeleteProductCommandResponse deleteProductCommandResponse = await _mediator.Send(deleteProductCommandRequest);
            return Ok(deleteProductCommandResponse);

        }


        [HttpPost("[action]")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AttributeConst.Products, ActionType = ActionType.Writing, Definiton = "Image Updload Product")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadProductCommandRequest ımageUploadProductCommandRequest)
        {

            ImageUploadProductCommandResponse ımageUploadProductCommandResponse = await _mediator.Send(ımageUploadProductCommandRequest);

            return Ok(ımageUploadProductCommandResponse);

        }


        [HttpGet("getimage/{ProductId}")]
        [AuthorizeDefinition(Menu = AttributeConst.Products, ActionType = ActionType.Reading, Definiton = "Get Image Product")]
        public async Task<IActionResult> GetImage([FromRoute] GetImageProductCommandRequest getImageProductCommandRequest)
        {


            List<GetImageProductCommandResponse> getImageProductCommandResponse = await _mediator.Send(getImageProductCommandRequest);

            return Ok(getImageProductCommandResponse);

        }



        [HttpGet("getallimage")]
        [AuthorizeDefinition(Menu = AttributeConst.Products, ActionType = ActionType.Reading, Definiton = "Get All Image Product")]
        public async Task<IActionResult> getallimage([FromRoute] GetAllImageProductQueryRequest getAllImageProductQueryRequest)
        {

            List<GetAllImageProductQueryResponse> getAllImageProductQueryResponses = await _mediator.Send(getAllImageProductQueryRequest);

            return Ok(getAllImageProductQueryResponses);


        }


        [HttpGet("getbyidproductallimages/{Id}")]
        [AuthorizeDefinition(Menu = AttributeConst.Products, ActionType = ActionType.Reading, Definiton = "Get By Id Product All Images")]
        public async Task<IActionResult> Getbyidproductallimages([FromRoute] GetByIdProductAllImagesQueryRequest getByIdProductAllImagesQueryRequest)
        {

            List<GetByIdProductAllImagesQueryResponse> getByIdProductAllImagesQueryResponses = await _mediator.Send(getByIdProductAllImagesQueryRequest);
            return Ok(getByIdProductAllImagesQueryResponses);


        }

        [HttpPut("vitrin")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AttributeConst.Products, ActionType = ActionType.Updateing, Definiton = "Change Show Case")]
        public async Task<IActionResult> Vitrin(ChangeShowCaseProductCommandRequest changeShowCaseProductCommandRequest)
        {
            ChangeShowCaseProductCommandResponse changeShowCaseProductCommandResponse = await _mediator.Send(changeShowCaseProductCommandRequest);
            return Ok(changeShowCaseProductCommandResponse);
        }

        [HttpPost("[action]")]
        [AuthorizeDefinition(Menu = AttributeConst.Products, ActionType = ActionType.Reading, Definiton = "Sort All Products")]
        public async Task<IActionResult> SortAllProducts(SortAllProductsQueryRequest sortAllProductsQueryRequest)
        {
            List<SortAllProductsQueryResponse> sortAllProductsQueryResponses = await _mediator.Send(sortAllProductsQueryRequest);
            return Ok(sortAllProductsQueryResponses);
        }

       


    }
}
