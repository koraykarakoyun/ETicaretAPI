using ETicaretAPI.Application.Abstraction.Basket;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.Basket;
using ETicaretAPI.Application.Repositories.BasketItem;
using ETicaretAPI.Application.Repositories.Order;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Persistence.Repositories;
using ETicaretAPI.Persistence.Repositories.Basket;
using ETicaretAPI.Persistence.Repositories.BasketItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Basket
{
    public class BasketService : IBasketService
    {

        private IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        IOrderReadRepository _orderReadRepository;
        IOrderWriteRepository _orderWriteRepository;
        IBasketItemReadRepository _basketItemReadRepository;
        IBasketItemWriteRepository _basketItemWriteRepository;
        IBasketReadRepository _basketReadRepository;
        readonly IBasketWriteRepository _basketWriteRepository;
   
      

        public BasketService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, IBasketItemReadRepository basketItemReadRepository, IBasketItemWriteRepository basketItemWriteRepository, IBasketReadRepository basketReadRepository, IBasketWriteRepository basketWriteRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _basketItemReadRepository = basketItemReadRepository;
            _basketItemWriteRepository = basketItemWriteRepository;
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
            
        }






        private async Task<Domain.Entities.Basket?> ContextUser()
        {
            string? username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(username))
            {
                AppUser? user = await _userManager.Users.Include(b => b.Basket).FirstOrDefaultAsync(u => u.UserName == username);
          
                var _basket = from basket in user.Basket
                              join order in _orderReadRepository.Table on basket.Id equals order.Id into BasketOrders
                              from orderempty in BasketOrders.DefaultIfEmpty()
                              select new
                              {
                                  Basket = basket,
                                  Order = orderempty
                              };

                Domain.Entities.Basket? _targetbasket = null;

                if (_basket.Any(b => b.Order is null))
                {
                    _targetbasket = _basket.FirstOrDefault(b => b.Order is null).Basket;

                }
                else
                {
                    _targetbasket = new()
                    {
                        UserId=user.Id
                    };
                    user.Basket.Add(_targetbasket);
                    await _basketWriteRepository.SaveAsync();
                }

                return _targetbasket;

            }
             
            throw new Exception();
           
        }

        public async Task<bool> AddItemToBasketAsync(Create_BasketItem basketItem)
        {


            Domain.Entities.Basket basket = await ContextUser();

            if (basket != null)
            {

                BasketItem _basketItem = await _basketItemReadRepository.GetSingleAsync(bi => bi.BasketId == basket.Id && bi.ProductId == Guid.Parse(basketItem.ProductId));

                if (_basketItem != null)
                {
                    _basketItem.Quantity++;
                }
                else
                {
                    await _basketItemWriteRepository.AddAsync(new BasketItem()
                    {
                        
                        BasketId = basket.Id,
                        ProductId = Guid.Parse(basketItem.ProductId),
                        Quantity = basketItem.Quantity

                    });
                }
                await _basketItemWriteRepository.SaveAsync();
                return true;

            }
            return false;

        }

        public async Task<List<BasketItem>> GetBasketItems()
        {

            Domain.Entities.Basket _basket = await ContextUser();
            Domain.Entities.Basket result = await _basketReadRepository.Table.Include(bi => bi.BasketItems).ThenInclude(p => p.Product).FirstOrDefaultAsync(b => b.Id == _basket.Id);

            return result.BasketItems.ToList();


        }

        public async Task<bool> RemoveBasketItemAsync(string basketItemId)
        {
            BasketItem basketItem = await _basketItemReadRepository.GetSingleAsync(b => b.Id == Guid.Parse(basketItemId));
            if (basketItem != null)
            {
                _basketItemWriteRepository.Remove(basketItem);
                await _basketItemWriteRepository.SaveAsync();
                return true;
            }
            return false;

        }

        public async Task<bool> UpdateQuantityAsync(Update_BasketItem basketItem)
        {
            BasketItem _basketItem = await _basketItemReadRepository.GetSingleAsync(b => b.Id == Guid.Parse(basketItem.BasketItemId));
            if (_basketItem != null)
            {
                _basketItem.Quantity = basketItem.Quantity;
                await _basketItemWriteRepository.SaveAsync();
                return true;
            }
            return false;

        }
    }
}
