using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.File;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
    public class GetAllOrdersByUserDto
    {

        public GetAllOrdersByUserDto()
        {

            Paths = new List<string>();
           
        }
        public string OrderCode { get; set; }

        public float TotalPrice { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<string> Paths { get; set; } 

    }
}
