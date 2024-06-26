﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetFilteredCategoryProducts
{
    public class GetCategoryFiltersRequest : IRequest<GetCategoryFiltersResponse>
    {
        public string Category { get; set; }
    }
}
