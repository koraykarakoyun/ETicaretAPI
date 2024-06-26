﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
    public class GetAllProductsDto
    {
        public string CategoryName { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public float ProductPrice { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }

        public bool ShowCase { get; set; }
        public string Path { get; set; }
    }
}
