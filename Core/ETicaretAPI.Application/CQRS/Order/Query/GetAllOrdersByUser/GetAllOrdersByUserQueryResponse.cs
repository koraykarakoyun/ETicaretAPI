using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Domain.Entities.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Order.Query.GetAllOrdersByUser
{
    public class GetAllOrdersByUserQueryResponse
    {
        public List<GetAllOrdersByUserDto> Data { get; set; }

    }
}
