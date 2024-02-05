using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretApi.Domain.Entities;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext : DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options) { } //bu benim veritabanim , ioc cointanier'a bunu ilerde tanimlatacagiz

        public DbSet<Product> products { get; set; } //database diyoruz ki Product formatinda bir tablo olustur
        public DbSet<Order> orders { get; set; } //database diyoruz ki orders formatinda bir tablo olustur
        public DbSet<Customer> customers { get; set; } //database diyoruz ki customers formatinda bir tablo olustur

    }
}
