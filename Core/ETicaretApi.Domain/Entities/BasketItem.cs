using ETicaretApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Domain.Entities
{
    public class BasketItem : BaseEntity
    {
        //hangi urunleri tutacagini bilecek, 
        //hangi baskete karsiligini geldigini bilecek
        // urunlerle ilgili ekstradan bilgi tutcak kac adet, aciklma vs
        public Guid ProductId { get; set; }
        public Guid BasketId { get; set; }    
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Basket Basket { get; set; }
    }
}
