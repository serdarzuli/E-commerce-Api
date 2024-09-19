using ETicaretApi.Domain.Entities.Common;
using ETicaretApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public string UsertId { get; set; }
        public AppUser User { get; set; } //sepetin birtane kullanicisi olabilir, AppUserin icerisine giderek Bir userin birden fazla sepeti oalbilir tanimlamasini yapalim ICollection ile
        public ICollection<BasketItem> BasketItems { get; set; } //bir basket iciersinde birden fazla item olabilir
    }
}
