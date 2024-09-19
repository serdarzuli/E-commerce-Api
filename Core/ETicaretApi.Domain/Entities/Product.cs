using ETicaretApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
        public ICollection<Order> Orders { get; set; } //n-n iliski Prodcuts ile Orders iliskilendirdik 
        public ICollection<BasketItem> BasketItems { get; set; } // bu prodcut kac kere sepete eklenmis diye soru sorabiliriz, burada ki collection ile bunu halledeiyoruz

    }
    //entiteslerin ilk adimi prodctur

    //Bir urunumuz var ve bu urunun Name , Stok durumu ve Fiyati var
    // BaseEntity'den miras aldigi icin arka planda Id'si ve Date' kismida bulunmakta
}
