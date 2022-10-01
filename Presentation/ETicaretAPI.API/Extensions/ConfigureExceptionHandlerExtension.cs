using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace ETicaretAPI.API.Extensions
{
    public static class ConfigureExceptionHandlerExtension
    {
        public static void ConfigureExceptionHandler<T>(this WebApplication application,ILogger<T> logger)
        {

            application.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    var contextfeature= context.Features.Get<IExceptionHandlerFeature>();
                    if (contextfeature != null)
                    {
                        logger.LogError(contextfeature.Error.Message);

                       await context.Response.WriteAsync(JsonSerializer.Serialize(new
                       {
                           Code=context.Response.StatusCode,
                           message=contextfeature.Error.Message,
                           Title="Hata alındı"
                       }));

                    }

                });
            });

        }
    }
}
