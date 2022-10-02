using ETicaretAPI.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.SignalR.Extensions
{
    public static class MapHubExtension
    {
        public static void AddMapHub(this WebApplication webApplication)
        {
            webApplication.MapHub<ProductHub>("product-hub");
        }
    }
}
