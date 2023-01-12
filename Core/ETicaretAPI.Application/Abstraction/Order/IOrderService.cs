using ETicaretAPI.Application.CQRS.Order.Query.GetAllOrdersByUser;
using ETicaretAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.Order
{
    public interface IOrderService
    {

        Task CreateOrder(CreateOrderDto createOrderDto);

        Task<List<GetAllOrderDto>> GetAllOrder();

        Task<OrderDetailDto> GetOrderDetailById(string Id);
        
        Task<bool> CompleteOrderAsync(string Id);

        Task<List<GetAllOrdersByUserDto>> GetAllOrdersByUser();

        Task<GetByIdUserOrderDetailDto> GetByIdUserOrderDetail(string OrderCode);

        Task<bool> DeleteOrderByOrderCodeAsync(string OrderCode);
    }
}
