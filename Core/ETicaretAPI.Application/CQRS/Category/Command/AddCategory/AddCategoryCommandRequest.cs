using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Category.Command.AddCategory
{
    public class AddCategoryCommandRequest:IRequest<AddCategoryCommandResponse>
    {
        public string Name { get; set; }
    }
}
