using ETicaretAPI.Application.Abstraction.Basket;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Basket
{
    public class BasketService : IBasketService
    {

        IHttpContextAccessor _httpContextAccessor;

        public BasketService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task AddItemToBasketAsync(Create_BasketItem basketItem)
        {
            throw new NotImplementedException();
        }

        public Task<List<BasketItem>> GetBasketItems()
        {
            throw new NotImplementedException();
        }

        public Task RemoveBasketItemAsync(string basketItemId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateQuantityAsync(Update_BasketItem basketItem)
        {
            throw new NotImplementedException();
        }
    }
}
