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
            /*
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
            */

            /*
            Product p = await _productReadRepository.GetByIdAsync("10c1cddf-7fd9-499c-b5fa-92df3b9cb65f",false);

            p.Name = "isim degistirildi";

             await _productWriteRepository.SaveAsync();
            */


            // await _productWriteRepository.SaveAsync();

            return Ok();
        }

    }
}
