using ETicaretApi.Domain.Entities.Common;
using ETicaretApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Customer : BaseEntity
    {
        //1-n iliski olusturalim
        public ICollection<Order>? Orders { get; set; }
    }
}
