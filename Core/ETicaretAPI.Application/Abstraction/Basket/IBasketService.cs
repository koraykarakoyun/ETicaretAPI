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
        Task AddItemToBasketAsync(Create_BasketItem basketItem);
        Task UpdateQuantityAsync(Update_BasketItem basketItem);
        Task RemoveBasketItemAsync(string basketItemId);
    }
}
