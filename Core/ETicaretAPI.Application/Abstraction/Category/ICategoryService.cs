using ETicaretAPI.Application.CQRS.Category.Query.SortCategoryInProducts;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.Category
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(string Name);

        Task UpdateCategoryAsync(string Id, string NewCategoryName);

        Task DeleteByIdCategoryAsync(string Id);

        Task<List<Domain.Entities.Category>> GetAllCategoriesAsync();

        Task<Domain.Entities.Category> GetByIdCategoryAsync(string CategoryId);

        Task<List<GetByIdCategoryInProductsDto>> GetByIdCategoryInProductsAsync(string CategoryId);

        Task<List<GetByNameCategoryInProductsDto>> GetByNameCategoryInProductsAsync(string CategoryName);

        Task<List<SortCategoryInProductsDto>> SortCategoryInProductsAsync(string CategoryName,string type,string parameter);

    }
}
