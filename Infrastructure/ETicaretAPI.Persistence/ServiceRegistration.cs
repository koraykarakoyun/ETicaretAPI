﻿
using ETicaretAPI.Application.Abstraction.Auth;
using ETicaretAPI.Application.Abstraction.AuthorizationEndpoint;
using ETicaretAPI.Application.Abstraction.Basket;
using ETicaretAPI.Application.Abstraction.Category;
using ETicaretAPI.Application.Abstraction.Order;
using ETicaretAPI.Application.Abstraction.Product;
using ETicaretAPI.Application.Abstraction.Role;
using ETicaretAPI.Application.Abstraction.User;
using ETicaretAPI.Application.Abstraction.UserAuthRole;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.Basket;
using ETicaretAPI.Application.Repositories.BasketItem;
using ETicaretAPI.Application.Repositories.Category;
using ETicaretAPI.Application.Repositories.CompletedOrder;
using ETicaretAPI.Application.Repositories.Endpoint;
using ETicaretAPI.Application.Repositories.InvoiceFile;
using ETicaretAPI.Application.Repositories.Menu;
using ETicaretAPI.Application.Repositories.Order;
using ETicaretAPI.Application.Repositories.ProductDetail;
using ETicaretAPI.Application.Repositories.ProductDetails;
using ETicaretAPI.Application.Repositories.ProductImageFile;
using ETicaretAPI.Application.Repositories.Slider;
using ETicaretAPI.Application.Repositories.UserAuthRoles;
using ETicaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Persistence.Auth;
using ETicaretAPI.Persistence.AuthorizationEndpoint;
using ETicaretAPI.Persistence.Basket;
using ETicaretAPI.Persistence.Category;
using ETicaretAPI.Persistence.Context;
using ETicaretAPI.Persistence.Repositories;
using ETicaretAPI.Persistence.Repositories.Basket;
using ETicaretAPI.Persistence.Repositories.BasketItem;
using ETicaretAPI.Persistence.Repositories.Category;
using ETicaretAPI.Persistence.Repositories.CompletedOrder;
using ETicaretAPI.Persistence.Repositories.Endpoint;
using ETicaretAPI.Persistence.Repositories.File;
using ETicaretAPI.Persistence.Repositories.InvoiceFile;
using ETicaretAPI.Persistence.Repositories.Menu;
using ETicaretAPI.Persistence.Repositories.Order;
using ETicaretAPI.Persistence.Repositories.ProductDetail;
using ETicaretAPI.Persistence.Repositories.ProductImageFile;
using ETicaretAPI.Persistence.Repositories.Slider;
using ETicaretAPI.Persistence.Repositories.UserAuthRoles;
using ETicaretAPI.Persistence.Role;
using ETicaretAPI.Persistence.User;
using ETicaretAPI.Persistence.UserAuthRole;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddDbContext<ETicaretDbContext>(options => options.UseSqlServer("Server=DESKTOP-3AI1OI3;Database=ETicaretApi;Trusted_Connection=True;"));
            services.AddIdentity<AppUser, AppRole>(_ =>
                {
                    _.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+/ ";
                    _.User.RequireUniqueEmail = true;
                }
                )
            .AddEntityFrameworkStores<ETicaretDbContext>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();

            services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
            services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
            services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();

            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();

            services.AddScoped<ICompletedOrderReadRepository, CompletedOrderReadRepository>();
            services.AddScoped<ICompletedOrderWriteRepository, CompletedOrderWriteRepository>();

            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();

            services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
            services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();

            services.AddScoped<IUserAuthRolesReadRepository, UserAuthRolesReadRepository>();
            services.AddScoped<IUserAuthRolesWriteRepository, UserAuthRolesWriteRepository>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<ISliderReadRepository, SliderReadRepository>();
            services.AddScoped<ISliderWriteRepository, SliderWriteRepository>();

            services.AddScoped<IProductDetailReadRepository, ProductDetailReadRepository>();
            services.AddScoped<IProductDetailWriteRepository, ProductDetailWriteRepository>();


            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();



            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthService, AuthService>();
            services.AddScoped<IInternalAuthService, AuthService>();

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();
            services.AddScoped<IUserAuthRoleService, UserAuthRoleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
