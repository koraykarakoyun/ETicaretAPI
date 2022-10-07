using ETicaretAPI.Application.Abstraction.Services;
using ETicaretAPI.Application.Token;
using ETicaretAPI.Infrastructure.Services.File;
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
            services.AddScoped<IFileServices, FileServices>();

        }
    }
}
