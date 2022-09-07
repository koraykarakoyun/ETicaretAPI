﻿using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ProductWriteRepository : WriteRepsitory<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}