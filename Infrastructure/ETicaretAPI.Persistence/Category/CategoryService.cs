using ETicaretAPI.Application.Abstraction.Category;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Repositories.Category;
using ETicaretAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Category
{
    public class CategoryService : ICategoryService
    {

        ICategoryReadRepository _categoryReadRepository;
        ICategoryWriteRepository _categoryWriteRepository;

        public CategoryService(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task AddCategoryAsync(string Name)
        {
            await _categoryWriteRepository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                Name = Name
            });
            await _categoryWriteRepository.SaveAsync();
        }

        public async Task DeleteByIdCategoryAsync(string Id)
        {
            await _categoryWriteRepository.RemoveByIdAsync(Id);
            await _categoryWriteRepository.SaveAsync();
        }

        public async Task<List<Domain.Entities.Category>> GetAllCategoriesAsync()
        {
            return await _categoryReadRepository.GetAll(tracking: false).ToListAsync();

        }

        public async Task UpdateCategoryAsync(string Id, string NewCategoryName)
        {
            Domain.Entities.Category category = await _categoryReadRepository.GetByIdAsync(Id);
            category.Name = NewCategoryName;
            await _categoryWriteRepository.SaveAsync();
        }



        public async Task<List<GetCategoryInProductsDto>> GetCategoryInProductsAsync(string CategoryId)
        {
            Domain.Entities.Category? category = await _categoryReadRepository.Table.Include(p => p.Products).SingleOrDefaultAsync(a => a.Id == Guid.Parse(CategoryId));
            return category.Products.Select(a => new GetCategoryInProductsDto()
            {
                CategoryId = a.Category.Id.ToString(),
                CategoryName = a.Category.Name,
                ProductId = a.Id.ToString(),
                ProductName = a.Name,
                ProductPrice = a.Price,
                ProductStock = a.Stock,
            }).ToList();

        }

        public async Task<Domain.Entities.Category> GetByIdCategoryAsync(string CategoryId)
        {
             return await _categoryReadRepository.GetByIdAsync(CategoryId);
        }
    }
}
