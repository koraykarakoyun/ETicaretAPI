using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.Basket
{
    public interface IBasketService
    {

        Task<List<BasketItem>> GetBasketItems();
        Task<bool> AddItemToBasketAsync(Create_BasketItem basketItem);
        Task<bool> UpdateQuantityAsync(Update_BasketItem basketItem);
        Task<bool> RemoveBasketItemAsync(string basketItemId);
        Task<Domain.Entities.Basket?> GetUserActiveBasket();
    }
}
