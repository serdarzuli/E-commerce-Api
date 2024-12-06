using ETicaretApi.Application.Abstractions.Hubs;
using ECommerce.SignalR.HubService;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.SignalR

{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection collection)
        {
                                                   collection.AddTransient<IProductHubService, ProductHubService>();
            collection.AddSignalR();
        }
    }
}
