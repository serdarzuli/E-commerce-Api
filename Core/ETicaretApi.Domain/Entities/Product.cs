using ETicaretApi.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Domain.Entities
{
    //entiteslerin ilk adimi prodctur

    //Bir urunumuz var ve bu urunun Name , Stok durumu ve Fiyati var
    // BaseEntity'den miras aldigi icin arka planda Id'si ve Date' kismida bulunmakta
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
        public ICollection<Order> Orders { get; set; } //n-n iliski Prodcuts ile Orders iliskilendirdik 

    }
}
