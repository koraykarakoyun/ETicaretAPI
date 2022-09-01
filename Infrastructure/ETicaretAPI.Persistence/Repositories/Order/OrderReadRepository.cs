﻿using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class OrderReadRepository : ReadRepository<Order>,IOrderReadRepository
    {
        public OrderReadRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
