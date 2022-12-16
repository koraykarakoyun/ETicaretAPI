using ETicaretAPI.Application.Abstraction.Category;
using ETicaretAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Category.Query.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, List<GetAllCategoriesQueryResponse>>
    {

        ICategoryService _categoryService;

        public GetAllCategoriesQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<List<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Category> categories = await _categoryService.GetAllCategoriesAsync();

            return categories.Select(a => new GetAllCategoriesQueryResponse()
            {
                Id = a.Id.ToString(),
                Name = a.Name
            }).ToList();

        }
    }
}
