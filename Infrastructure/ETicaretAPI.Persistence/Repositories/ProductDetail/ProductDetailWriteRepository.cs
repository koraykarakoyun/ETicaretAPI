using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.ProductDetail;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.ProductDetail
{
    public class ProductDetailWriteRepository : WriteRepsitory<Domain.Entities.ProductDetail>, IProductDetailWriteRepository
    {
        public ProductDetailWriteRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
