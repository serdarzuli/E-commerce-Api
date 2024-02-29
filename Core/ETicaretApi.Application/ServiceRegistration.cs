using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretApi.Application
{
    // Presentation katmaninda bulunan IOC'ye burada ki serviceleri tanimlatacagiz.
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ServiceRegistration));
            // AddMediatR bizden bir assembly istiyor biz de "ServiceRegistration" verdik, şu anlama geliyor Static verdiğimiz için sadece
            // ETıcaretApi.Applicationı(Assembly) temsil ediyor ve MediatR diyorki burada bulunan butun IHandler IRequest vs alayını MediatR yapısına uygun şekilde hazırlıycam

        }
    }
}
