using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.SignalR
{
    public interface IProductHubService
    {
        Task AddedProductMessage(string message);
    }
}
