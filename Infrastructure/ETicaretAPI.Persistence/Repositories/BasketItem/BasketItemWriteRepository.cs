using ETicaretAPI.Application.Repositories.BasketItem;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.BasketItem
{
    public class BasketItemWriteRepository : WriteRepsitory<Domain.Entities.BasketItem>, IBasketItemWriteRepository
    {
        public BasketItemWriteRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
