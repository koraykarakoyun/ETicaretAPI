using ETicaretAPI.Application.Repositories.ProductDetails;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.ProductDetail
{
    public class ProductDetailReadRepository : ReadRepository<Domain.Entities.ProductDetail>, IProductDetailReadRepository
    {
        public ProductDetailReadRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
