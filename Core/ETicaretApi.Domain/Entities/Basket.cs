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
        public Order Order { get; set; } //1-1 bir iliski olusturduk
        public AppUser User { get; set; } // sepeti kullanici  ile bagladik, sepetin birtane kullanicisi olabilir, AppUserin icerisine giderek Bir userin birden fazla sepeti oalbilir tanimlamasini yapalim ICollection ile
        public ICollection<BasketItem> BasketItems { get; set; } //sebeti items ile bagladik, bir basket iciersinde birden fazla item olabilir
    }
}
