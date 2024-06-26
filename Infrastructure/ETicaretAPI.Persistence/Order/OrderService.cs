﻿using ETicaretAPI.Application.Abstraction.Basket;
using ETicaretAPI.Application.Abstraction.Order;
using ETicaretAPI.Application.CQRS.Order.Query.GetAllOrdersByUser;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.Basket;
using ETicaretAPI.Application.Repositories.BasketItem;
using ETicaretAPI.Application.Repositories.CompletedOrder;
using ETicaretAPI.Application.Repositories.Order;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Persistence.Repositories.Basket;
using ETicaretAPI.Persistence.Repositories.BasketItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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
        IHttpContextAccessor _httpContextAccessor;
        UserManager<AppUser> _userManager;
        IBasketItemReadRepository _basketItemReadRepository;



        public OrderService(IOrderWriteRepository orderWriteRepository, IBasketService basketService, IOrderReadRepository orderReadRepository, IBasketReadRepository basketReadRepository, ICompletedOrderWriteRepository completedOrderWriteRepository, ICompletedOrderReadRepository completedOrderReadRepository, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IBasketItemReadRepository basketItemReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _basketService = basketService;
            _orderReadRepository = orderReadRepository;
            _basketReadRepository = basketReadRepository;
            _completedOrderWriteRepository = completedOrderWriteRepository;
            _completedOrderReadRepository = completedOrderReadRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _basketItemReadRepository = basketItemReadRepository;
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

        public async Task<bool> DeleteOrderByOrderCodeAsync(string OrderCode)
        {
            Order order = await _orderReadRepository.GetAll().SingleOrDefaultAsync(a => a.OrderCode == OrderCode);

            bool result = _orderWriteRepository.Remove(order);

            if (result)
            {
                await _orderWriteRepository.SaveAsync();
                return true;
            }
          
            throw new Exception("Sipariş Bulunamadı");


        }

        public async Task<List<GetAllOrderDto>> GetAllOrder()
        {

            var query = _orderReadRepository.Table.Include(o => o.Basket).ThenInclude(b => b.User)
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
                UserName = a.Basket.User.UserName,
                OrderCode = a.OrderCode,
                Address = a.Address,
                Description = a.Description,
                TotalPrice = a.Basket.BasketItems.Sum(bi => bi.Product.Price * bi.Quantity).ToString(),
                CreatedDate = a.CreatedDate,
                OrderCompleted = a.CompletedOrder,

            }).ToListAsync();

        }

        public async Task<List<GetAllOrdersByUserDto>> GetAllOrdersByUser()
        {

            string? username = _httpContextAccessor?.HttpContext?.User.Identity?.Name;

            var result = await _basketReadRepository.Table.Include(a => a.BasketItems).ThenInclude(a => a.Product).ThenInclude(a => a.ProductImageFiles)
                .Include(a => a.User).Include(a => a.Order).Where(a => a.User.UserName == username).ToListAsync();

            List<GetAllOrdersByUserDto> getAllOrdersByUserDtos = new List<GetAllOrdersByUserDto>();

            foreach (var item in result)
            {
                if (item.Order != null)
                {
                    GetAllOrdersByUserDto getAllOrdersByUserDto = new GetAllOrdersByUserDto();
                    getAllOrdersByUserDto.CreatedDate = item.CreatedDate;
                    getAllOrdersByUserDto.TotalPrice = item.BasketItems.Sum(a => a.Quantity * a.Product.Price);
                    getAllOrdersByUserDto.ProductQuantity = item.BasketItems.Sum(a => a.Quantity).ToString();
                    getAllOrdersByUserDto.OrderCode = item?.Order?.OrderCode?.ToString();
                    foreach (var basketItem in item.BasketItems)
                    {
                        foreach (var productImageFile in basketItem.Product.ProductImageFiles)
                        {
                            if (productImageFile.ShowCase == true)
                            {
                                getAllOrdersByUserDto.Paths.Add(productImageFile.Path);
                            }
                        }
                    }
                    getAllOrdersByUserDtos.Add(getAllOrdersByUserDto);
                }
            }

            return getAllOrdersByUserDtos;

        }

        public async Task<GetByIdUserOrderDetailDto> GetByIdUserOrderDetail(string OrderCode)
        {

            var result = await _orderReadRepository.Table.Include(a => a.Basket).ThenInclude(a => a.BasketItems).ThenInclude(a => a.Product).ThenInclude(a => a.ProductDetail)
                .Include(a => a.Basket).ThenInclude(a => a.BasketItems).ThenInclude(a => a.Product).ThenInclude(a => a.ProductImageFiles)
                 .Include(a => a.Basket).ThenInclude(a => a.BasketItems).ThenInclude(a => a.Product).ThenInclude(a => a.Category).SingleOrDefaultAsync(a => a.OrderCode == OrderCode);


            GetByIdUserOrderDetailDto getByIdUserOrderDetailDto = new GetByIdUserOrderDetailDto();
            getByIdUserOrderDetailDto.OrderDescription = result.Description;
            getByIdUserOrderDetailDto.OrderAddress = result.Address;
            getByIdUserOrderDetailDto.OrderCode = result.OrderCode;
            getByIdUserOrderDetailDto.OrderCreatedDate = result.CreatedDate;
            getByIdUserOrderDetailDto.TotalPrice = result.Basket.BasketItems.Sum(a => a.Quantity * a.Product.Price).ToString();

            foreach (var basketitem in result.Basket.BasketItems)
            {

                GetByIdUserOrderDetailProductInfoDto dto = new GetByIdUserOrderDetailProductInfoDto();

                dto.CategoryName = basketitem.Product.Category.Name;
                dto.ProductId = basketitem.Product.Id.ToString();
                dto.ProductName = basketitem.Product.Name;
                dto.ProductPrice = basketitem.Product.Price;
                dto.ProductQuantity = basketitem.Quantity;
                dto.ProductBrand = basketitem.Product.ProductDetail.Brand;
                dto.ProductModel = basketitem.Product.ProductDetail.Model;
                dto.ProductDescription = basketitem.Product.ProductDetail.Description;
                dto.ProductColor = basketitem.Product.ProductDetail.Color;

                foreach (var productImageFile in basketitem.Product.ProductImageFiles)
                {
                    if (productImageFile.ShowCase == true)
                    {
                        dto.Paths = productImageFile.Path;
                        break;
                    }

                }

                getByIdUserOrderDetailDto.ProductInfo.Add(dto);

            }

            getByIdUserOrderDetailDto.TotalProductCount = getByIdUserOrderDetailDto.ProductInfo.Sum(a => a.ProductQuantity).ToString();
            return getByIdUserOrderDetailDto;

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
