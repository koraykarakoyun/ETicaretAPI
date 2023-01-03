using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
    public class SortCategoryInProductsDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public float ProductPrice { get; set; }
        public string Path { get; set; }
        public bool ShowCase { get; set; }
    }
}
