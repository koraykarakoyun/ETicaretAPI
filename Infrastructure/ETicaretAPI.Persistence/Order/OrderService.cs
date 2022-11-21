using ETicaretAPI.Application.Abstraction.Basket;
using ETicaretAPI.Application.Abstraction.Order;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Repositories.Basket;
using ETicaretAPI.Application.Repositories.BasketItem;
using ETicaretAPI.Application.Repositories.CompletedOrder;
using ETicaretAPI.Application.Repositories.Order;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Repositories.Basket;
using ETicaretAPI.Persistence.Repositories.BasketItem;
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
        IBasketReadRepository _basketReadRepository;
        ICompletedOrderWriteRepository _completedOrderWriteRepository;
        ICompletedOrderReadRepository _completedOrderReadRepository;

        public OrderService(IOrderWriteRepository orderWriteRepository, IBasketService basketService, IOrderReadRepository orderReadRepository, IBasketReadRepository basketReadRepository, ICompletedOrderWriteRepository completedOrderWriteRepository, ICompletedOrderReadRepository completedOrderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _basketService = basketService;
            _orderReadRepository = orderReadRepository;
            _basketReadRepository = basketReadRepository;
            _completedOrderWriteRepository = completedOrderWriteRepository;
            _completedOrderReadRepository = completedOrderReadRepository;
        }

        public async Task<bool> CompleteOrderAsync(string Id)
        {
            Order order = await _orderReadRepository.GetByIdAsync(Id);
            if (order != null)
            {
                await _completedOrderWriteRepository.AddAsync(new CompletedOrder() { OrderId = Guid.Parse(Id) });
                await _completedOrderWriteRepository.SaveAsync();
                return true;
            }

            return false;
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

            var query = _orderReadRepository.Table.Include(o => o.Basket).ThenInclude(b => b.AppUser)
               .Include(o => o.Basket).ThenInclude(b => b.BasketItems).ThenInclude(p => p.Product);

            var result = from order in query
                         join completedorder in _completedOrderReadRepository.Table on
                         order.Id equals completedorder.OrderId into co
                         from _co in co.DefaultIfEmpty()
                         select new
                         {
                             Id = order.Id,
                             Basket = order.Basket,
                             OrderCode = order.OrderCode,
                             Address = order.Address,
                             Description = order.Description,
                             CreatedDate = order.CreatedDate,
                             CompletedOrder = _co != null ? true : false,
                         };





            return await result.Select(a => new GetAllOrderDto()
            {
                OrderBasketId = a.Id.ToString(),
                UserName = a.Basket.AppUser.UserName,
                OrderCode = a.OrderCode,
                Address = a.Address,
                Description = a.Description,
                TotalPrice = a.Basket.BasketItems.Sum(bi => bi.Product.Price * bi.Quantity).ToString(),
                CreatedDate = a.CreatedDate,
                OrderCompleted = a.CompletedOrder,

            }).ToListAsync();

        }

        public async Task<OrderDetailDto> GetOrderDetailById(string Id)
        {
            var data = _orderReadRepository.Table.Include(o => o.Basket).ThenInclude(bi => bi.BasketItems).ThenInclude(p => p.Product).FirstOrDefaultAsync(id => id.Id == Guid.Parse(Id)).Result;


            return new OrderDetailDto()
            {
                Id = data.Id.ToString(),
                OrderCode = data.OrderCode,
                Address = data.Address,
                Description = data.Description,
                CreatedDate = data.CreatedDate,
                BasketItems = data.Basket.BasketItems.Select(bi => new
                {
                    bi.Product.Name,
                    bi.Product.Price,
                    bi.Quantity,
                    TotalPrice = bi.Product.Price * bi.Quantity
                })
            };



        }
    }
}
