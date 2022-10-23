using ETicaretAPI.Application.Abstraction.Basket;
using ETicaretAPI.Application.Abstraction.Order;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Repositories.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public class OrderService : IOrderService
    {

        IOrderWriteRepository _orderWriteRepository;
        IBasketService _basketService;

        public OrderService(IOrderWriteRepository orderWriteRepository, IBasketService basketService)
        {
            _orderWriteRepository = orderWriteRepository;
            _basketService = basketService;
        }

        public async Task CreateOrder(CreateOrderDto createOrderDto)
        {
            Domain.Entities.Basket? basket = await _basketService.GetUserActiveBasket();


            await _orderWriteRepository.AddAsync(new Domain.Entities.Order()
            {
                Address = createOrderDto.Address,
                Description = createOrderDto.Description,
                OrderCode = Guid.NewGuid().ToString(),
                Basket = basket,
            });

            await _orderWriteRepository.SaveAsync();


        }
    }
}
