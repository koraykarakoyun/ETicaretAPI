﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Domain.Common;
using ETicaretAPI.Domain.Entities.File;

namespace ETicaretAPI.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }

        public int Stock { get; set; }

        public float Price { get; set; }

        public Guid CategoryId { get; set; }

        public ICollection<BasketItem> BasketItems { get; set; }

        //public ICollection<Order> Orders { get; set; }

        public ICollection<ProductImageFile> ProductImageFiles { get; set; }

        public Category Category { get; set; }

        public ProductDetail ProductDetail { get; set; }

    }
}
