using ETicaretApi.Application.Repositories;
using ETicaretApi.Persistence.Repositories;
using ETicaretAPI.Persistence;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence
{
    //Bu bir extencion metotdur
    public static class ServiceRegistration
    {
        //program.cs benim ioc container'im IServiceColection oldugundan ben de burada Dependency Injection yapmak istedigimde , aynisini kullaniyorum 
        public static void AddPersistenceServices(this IServiceCollection services) //bu bir extantion methoddur
        {
            #region Aciklama
            //services. dedigimde ilgili servislerimi burada ekleyebiliyorum
            //Product Controller icersinde olusturmus oldugum action'a bir istek geldiginde , ben apllication katmanindan Interface'e gelecek ve burada IProduct dedigimde bana sonuc olarak Persistence katmanindaki concreten Product donecek.
            //altaki kod yapisida, yukaridaki yapiyi gerceklestiecektir
            //extencion metotlari biz Presentationda ki IOC container'ina erisip oraya gerekli entengrasyonlari yapiyor olucaz  
            #endregion
            //services.AddSingleton<IProductService , ProductService>();


            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();





        }
        //bu metodu tetiklemek icin program.cs'te build edicez
    }
}
