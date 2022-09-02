using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
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


        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {

           var result= await _productReadRepository.GetByIdAsync("4e1fc388-816e-4bca-99b3-08da8cf6d418");

            result.Name = "isim degistirildi";

            await _productWriteRepository.SaveAsync();

            return Ok();
        }

    }
}
