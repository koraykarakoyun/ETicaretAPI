using ETicaretAPI.Application.Abstraction.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Category.Command.DeleteCategory
{
    public class DeleteByIdCategoryCommandHandler : IRequestHandler<DeleteByIdCategoryCommandRequest, DeleteByIdCategoryCommandResponse>
    {
        ICategoryService _categoryService;

        public DeleteByIdCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<DeleteByIdCategoryCommandResponse> Handle(DeleteByIdCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryService.DeleteByIdCategoryAsync(request.Id);
            return new()
            {
                Message = "Kategori Silinmiştir"
            };
        }
    }
}
