﻿using ETicaretAPI.Application.Repositories.ProductImageFile;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.ProductImageFile
{
    public class ProductImageFileWriteRepository : WriteRepsitory<Domain.Entities.File.ProductImageFile>, IProductImageFileWriteRepository
    {
        public ProductImageFileWriteRepository(ETicaretDbContext context) : base(context)
        {
        }
    }
}
