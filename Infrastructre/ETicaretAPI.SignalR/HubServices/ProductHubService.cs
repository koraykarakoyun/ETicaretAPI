using ETicaretAPI.Application.Abstraction.SignalR;
using ETicaretAPI.SignalR.Const;
using ETicaretAPI.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.SignalR.HubServices
{
    public class ProductHubService : IProductHubService
    {

        IHubContext<ProductHub> _hubContext;

        public ProductHubService(IHubContext<ProductHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task AddedProductMessage(string message)
        {
           await _hubContext.Clients.All.SendAsync(HubConst.ProductAdded,message);
        }
    }
}
