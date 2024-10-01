using ETicaretApi.Application.Abstractions.Hubs;
using Microsoft.AspNetCore.SignalR;
using ECommerce.SignalR.Hubs;

namespace ECommerce.SignalR.HubService
{
    public class ProductHubService : IProductHubService
    {
        readonly IHubContext<ProductHub> _hubContext; //IHubContext nereden geliyor? A: ServiceRegistration.cs de Add.SignalR(); geliyor butun referenceleri

        public ProductHubService(IHubContext<ProductHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task ProductAddedMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.ProductAddedMessage, message);
        }
    }
}
