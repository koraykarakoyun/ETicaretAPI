using ETicaretAPI.Application.Abstraction.Basket;
using ETicaretAPI.Application.Abstraction.Order;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Repositories.Order;
using Microsoft.EntityFrameworkCore;
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
        IOrderReadRepository _orderReadRepository;

        public OrderService(IOrderWriteRepository orderWriteRepository, IBasketService basketService, IOrderReadRepository orderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _basketService = basketService;
            _orderReadRepository = orderReadRepository;
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

        public async Task<List<GetAllOrderDto>> GetAllOrder()
        {

            return await _orderReadRepository.Table.Include(o => o.Basket).ThenInclude(b => b.AppUser)
                .Include(o => o.Basket).ThenInclude(b => b.BasketItems).ThenInclude(p => p.Product)

                .Select(a => new GetAllOrderDto()
                {
                    OrderBasketId=a.Id.ToString(),
                    UserName = a.Basket.AppUser.UserName,
                    OrderCode = a.OrderCode,
                    Address = a.Address,
                    Description = a.Description,
                    TotalPrice = a.Basket.BasketItems.Sum(bi => bi.Product.Price * bi.Quantity).ToString(),
                    CreatedDate=a.CreatedDate

                }).ToListAsync();

        }
    }
}
