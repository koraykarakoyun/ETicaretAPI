using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModel;
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
        public IActionResult GetAll()
        {

            return Ok(_productReadRepository.GetAll(false));
        }
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var query = await _productReadRepository.GetByIdAsync(id, false);
            return Ok(query);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ProductViewModel productViewModel)
        {
            await _productWriteRepository.AddAsync(
                new()
                {
                    Name = productViewModel.Name,
                    Stock = productViewModel.Stock,
                    Price = productViewModel.Price,

                });
            await _productWriteRepository.SaveAsync();
            return Ok("Eklendi");

        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(string id,ProductViewModel productViewModel)
        {

            var query = await _productReadRepository.GetByIdAsync(id);

            query.Name = productViewModel.Name;
            query.Price = productViewModel.Price;
            query.Stock = productViewModel.Stock;

            await _productWriteRepository.SaveAsync();



            return Ok("Guncellendi");

        }

        [HttpDelete("deletebyid/{id}")]
        public async Task<IActionResult> DeletebyId(string id)
        {
            await _productWriteRepository.RemoveByIdAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok("Silindi");

        }

    }
}
