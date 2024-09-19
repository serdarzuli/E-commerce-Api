using ETicaretApi.Application.Abstractions.Hubs;
using ECommerce.SignalR.HubService;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.SignalR

{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection collection)
        {
            //burada ki serviceregistration mantigi cok iyi bilmek lazim, yeni katman olan SIgnalR, interface aldigi sinif Application katmaninda ve simdi bu iki katman bir birini tanimasi lazim.
            // nasil taniyacaklar, iste bu sekilde herbir katmanda ServiceRegistration sinifi bulunmakta ve onun sayesinde
            // ondan sonra butun bu Serviceregistration siniflarini IOC container olan API katmaninda birlestiriyoruz, Program.cs'in icerisinde.
            collection.AddTransient<IProductHubService, ProductHubService>();
            collection.AddSignalR();
        }
    }
}
