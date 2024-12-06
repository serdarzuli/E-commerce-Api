using Microsoft.EntityFrameworkCore;
using ETicaretApi.Domain.Entities;
using ETicaretApi.Domain.Entities.Common;
using ETicaretApi.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext : IdentityDbContext<AppUser>
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options) { }  

        public DbSet<Product> Products { get; set; }          public DbSet<Order> Orders { get; set; }          public DbSet<Customer> Customers { get; set; }          public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)          {
            builder.Entity<Order>().
                HasKey(b => b.Id);  
            builder.Entity<Basket>()
                .HasOne(b => b.Order)                  .WithOne(o => o.Basket)                  .HasForeignKey<Order>(b => b.Id);  
            base.OnModelCreating(builder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
                                       
                        var datas =  ChangeTracker
                        .Entries<BaseEntity>();

           foreach ( var i in datas)
           {
                _ = i.State switch
                {
                    EntityState.Added => i.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => i.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
           }

            
           
            return await base.SaveChangesAsync(cancellationToken);
        }
        
    }
}
