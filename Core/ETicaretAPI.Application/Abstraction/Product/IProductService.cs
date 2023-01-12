using ETicaretAPI.Application.CQRS.Product.Query.GetAllFilter;
using ETicaretAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.Product
{
    public interface IProductService
    {

        Task<GetAllFiltersDto> GetAllFiltersAsync();
        Task<List<GetAllFilteredProductsDto>> GetAllFilteredProductsAsync(string? brand = null, string? model = null, string? color = null, string? category = null);

        Task<GetCategoryFiltersDto> GetCategoryFiltersAsync(string categoryName);
    }
}
