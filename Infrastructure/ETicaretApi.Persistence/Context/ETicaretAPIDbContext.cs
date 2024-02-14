using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretApi.Domain.Entities;
using ETicaretApi.Domain.Entities.Common;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext : DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options) { } //bu benim veritabanim , ioc cointanier'a bunu ilerde tanimlatacagiz (tanimladim)

        public DbSet<Product> products { get; set; } //database diyoruz ki Product formatinda bir tablo olustur
        public DbSet<Order> orders { get; set; } //database diyoruz ki orders formatinda bir tablo olustur
        public DbSet<Customer> customers { get; set; } //database diyoruz ki customers formatinda bir tablo olustur

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //changeTracker : entitylerde yapilan degisiklerin yada yeni eklenen verinin yakalnmasini saglayan proportydir.
            //Updated operasyonlarinda Track edilen verileri yakalayip elde etmemizi saglar. 
            //Insert)selecet) disinda track edilen herhangi bir nesneyi de yakalyabiliyoruz

            // Entries surece giren girdileri buradan istedgimiz sekilde kosullara taabi tutabiliriz.
           var datas =  ChangeTracker
                        .Entries<BaseEntity>();

           foreach ( var i in datas)
           {
                _ = i.State switch
                {
                    EntityState.Added => i.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => i.Entity.UpdatedDate = DateTime.UtcNow
                };
           }

            
           
            return await base.SaveChangesAsync(cancellationToken);
        }
        
    }
}
