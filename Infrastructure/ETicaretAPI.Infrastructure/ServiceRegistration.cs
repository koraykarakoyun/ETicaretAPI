using ETicaretAPI.Application.Abstraction.ApplicationServices;
using ETicaretAPI.Application.Abstraction.Storage;
using ETicaretAPI.Application.Token;
using ETicaretAPI.Infrastructure.Services.ApplicationServices;
using ETicaretAPI.Infrastructure.Services.Storage;
using ETicaretAPI.Infrastructure.Token;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IStorageService,StorageService>();
            services.AddScoped<IApplicationServices, ApplicationServices>();
        }


        public static void AddStoreage<T>(this IServiceCollection services) where T:class,IStorage
        {
            services.AddScoped<IStorage, T>();
        }
    }
}
