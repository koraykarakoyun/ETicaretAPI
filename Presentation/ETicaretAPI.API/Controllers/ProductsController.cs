using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            await _productWriteRepository.AddAsync(

                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Deneme Ürünü2",
                    CreatedDate = DateTime.Now,
                    Price = 200,
                    Stock = 10

                }

                );

             await _productWriteRepository.SaveAsync();

            return Ok("Kayıt yapıldı");
        }

    }
}
